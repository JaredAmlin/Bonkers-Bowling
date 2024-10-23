using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    #region Variables
    [Header("Ten Pin Game Objects")]
    [SerializeField] private Pin[] _tenPins;

    [Header("Instantiated Pins")]
    [SerializeField] private GameObject _collectablePin;
    [SerializeField] private GameObject _avoidPin;
    [SerializeField] private GameObject _movingPin;

    [Header("Scriptable Object Pin Positions")]
    private List<Vector3> _collectablePinPositions;
    private List<Vector3> _avoidPinPositions;
    private List<Vector3> _movingPinPositions;
    [SerializeField] private PinPositions[] _collectablePinPositionsSO;
    [SerializeField] private PinPositions[] _avoidPinPositionsSO;
    [SerializeField] private PinPositions[] _movingPinPositionsSO;

    [Header("Pin Parent for Instantiating")]
    [SerializeField] private Transform _pinParent;

    [Header("Pin Detection")]
    [SerializeField] private int _pinsDown;
    [SerializeField] private int _pinsCollected;
    [SerializeField] private bool _redPinHit = false;
    [SerializeField] private int _pinsCompleted;
    private bool _pinCheck;

    //win conditions
    private bool _isStrike = false;
    private bool _isCollected = false;

    private WaitForSeconds _pinWaitTime = new WaitForSeconds(1f);
    
    public static event Action onResetPins;
    public static event Action onPinCheck;
    public static event Action<bool, bool, bool, int, int, int> onResultsCalculated;
    public static event Action<int> onGameStart;

    private const string _collectablePinName = "Collectable Pin";
    private const string _avoidPinName = "Dummy Pin";
    private const string _movingPinName = "Moving Dummy Pin";
    private const string _pinParentName = "Pin Parent";
    #endregion

    #region Initialization
    private void Start()
    {
        NullChecks();

        Subscribe();

        //initialize lists
        _collectablePinPositions = new List<Vector3>();
        _avoidPinPositions = new List<Vector3>();
        _movingPinPositions = new List<Vector3>();

        onGameStart?.Invoke(_collectablePinPositionsSO.Length);
    }

    private void NullChecks()
    {
        if (_collectablePin == null)
            _collectablePin = Resources.Load<GameObject>(_collectablePinName);

        if (_avoidPin == null)
            _avoidPin = Resources.Load<GameObject>(_avoidPinName);

        if (_movingPin == null)
            _movingPin = Resources.Load<GameObject>(_movingPinName);

        if (_pinParent == null)
        {
            Transform pinParent = GameObject.FindGameObjectWithTag(_pinParentName).transform;

            if (pinParent != null)
            {
                _pinParent = pinParent;
            }
        }

        if (_tenPins.Length == 0)
        {
            _tenPins = FindObjectsOfType<Pin>();
        }
    }

    private void Subscribe()
    {
        CollectablePin.onCollectablePin += CollectablePin_onCollectablePin;
        AvoidPin.onAvoidPin += AvoidPin_onAvoidPin;
        MovingPin.onAvoidPin += MovingPin_onAvoidPin;

        GameManager.onChallengeStart += GameManager_onChallengeStart;
        GameManager.onChallengeComplete += GameManager_onChallengeComplete;
        Pin.onPinComplete += Pin_onPinComplete;
    }
    #endregion

    #region Event Methods
    private void MovingPin_onAvoidPin()
    {
        _redPinHit = true;
    }

    private void Pin_onPinComplete()
    {
        _pinsCompleted++;
    }

    private void GameManager_onChallengeComplete()
    {
        StartCoroutine(WaitForPins());
        //check pins
        onPinCheck?.Invoke();
    }

    private void GameManager_onChallengeStart(int throwCount)
    {
        onResetPins?.Invoke();

        _redPinHit = false;
        _isStrike = false;
        _isCollected = false;
        _pinsCollected = 0;
        _pinsDown = 0;
        _pinsCompleted = 0;

        //clear lists
        _collectablePinPositions.Clear();
        _avoidPinPositions.Clear();
        _movingPinPositions.Clear();

        if (throwCount <= _collectablePinPositionsSO.Length - 1)
            SetPins(throwCount);
    }

    private void AvoidPin_onAvoidPin()
    {
        _redPinHit = true;
    }

    private void CollectablePin_onCollectablePin()
    {
        _pinsCollected++;
    }
    #endregion

    #region Private Methods
    private void SetPins(int throwCount)
    {
        //collectable pins
        foreach (Vector3 position in _collectablePinPositionsSO[throwCount].positions)
        {
            _collectablePinPositions.Add(position);
        }

        for (int i = 0; i < _collectablePinPositions.Count; i++)
        {
            Instantiate(_collectablePin, _collectablePinPositions[i], Quaternion.identity, _pinParent);
        }

        //avoid pins
        foreach (Vector3 position in _avoidPinPositionsSO[throwCount].positions)
        {
            _avoidPinPositions.Add(position);
        }

        for (int i = 0; i < _avoidPinPositions.Count; i++)
        {
            Instantiate(_avoidPin, _avoidPinPositions[i], Quaternion.identity, _pinParent);
        }

        //moving pins
        foreach (Vector3 position in _movingPinPositionsSO[throwCount].positions)
        {
            _movingPinPositions.Add(position);
        }

        for (int i = 0; i < _movingPinPositions.Count; i++)
        {
            Instantiate(_movingPin, _movingPinPositions[i], Quaternion.identity, _pinParent);
        }
    }

    private void CheckPins()
    {
        foreach (Pin pin in _tenPins)
        {
            _pinCheck = pin.PinDown();

            if (_pinCheck)
                _pinsDown++;
        }

        CalculateResults();
    }

    private void CalculateResults()
    {
        if (_pinsCollected == _collectablePinPositions.Count)
            _isCollected = true;

        if (_pinsDown == 10)
            _isStrike = true;

        onResultsCalculated?.Invoke(_isStrike, _isCollected, _redPinHit, _pinsCollected, _collectablePinPositions.Count, _pinsDown);
    }
    #endregion

    private void OnDisable()
    {
        CollectablePin.onCollectablePin -= CollectablePin_onCollectablePin;
        AvoidPin.onAvoidPin -= AvoidPin_onAvoidPin;
        MovingPin.onAvoidPin -= MovingPin_onAvoidPin;

        GameManager.onChallengeStart -= GameManager_onChallengeStart;
        GameManager.onChallengeComplete -= GameManager_onChallengeComplete; 
        Pin.onPinComplete -= Pin_onPinComplete;
    }

    private IEnumerator WaitForPins()
    {
        while (_pinsCompleted < 10)
        {
            yield return _pinWaitTime;
        }

        CheckPins();
    }
}
