using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Pin : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _startingPosition;
    private Quaternion _startingRotation;
    private float _distance;

    [Header("Pin Down Detection")]
    [SerializeField] private float _rotationTolerance = 20f;
    [SerializeField] private float _positionTolerance = 0.1f;
    [SerializeField] private float _minAngularVelocity = 0.05f;
    private float _angle;
    [SerializeField] private bool _isDown = false;

    private WaitForSeconds _pinCheckTime = new WaitForSeconds(1f);

    public static event Action onPinComplete;

    // Start is called before the first frame update
    void Start()
    {
        if (_rb == null & TryGetComponent<Rigidbody>(out Rigidbody rb))
            _rb = rb;

        _startingPosition = _rb.position;
        _startingRotation = _rb.rotation;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        PinManager.onResetPins += PinManager_onResetPins;
        PinManager.onPinCheck += PinManager_onPinCheck;
    }

    private void OnDisable()
    {
        PinManager.onResetPins -= PinManager_onResetPins;
        PinManager.onPinCheck -= PinManager_onPinCheck;
    }

    #region Event Methods
    private void PinManager_onPinCheck()
    {
        StartCoroutine(PinCheck());
    }

    private void PinManager_onResetPins()
    {
        _isDown = false;
        _rb.position = _startingPosition;
        _rb.rotation = _startingRotation;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
    #endregion

    public bool PinDown()
    {
        return _isDown;
    }

    private IEnumerator PinCheck()
    {
        yield return _pinCheckTime;

        while (_rb.angularVelocity.sqrMagnitude > _minAngularVelocity)
        {
            yield return _pinCheckTime;
        }

        //used to check how far the pin has moved and rotated from it's starting position and rotation
        _angle = Quaternion.Angle(_rb.rotation, _startingRotation);
        _distance = Vector3.Distance(_rb.position, _startingPosition);

        Debug.Log("Angle " + _angle);
        Debug.Log("Distance " + _distance);

        if (_angle > _rotationTolerance | _distance > _positionTolerance)
        {
            _isDown = true;
            //Debug.Log("Pin DOWN");
        }

        onPinComplete?.Invoke();
    }
}
