using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _throwCount;
    private int _consecutiveThrows;
    private int _totalThrows;
    private bool _turnComplete = false;
    private bool _objectivesComplete = false;
    private bool _isGameOver = false;
    private int _mainMenuScene = 0, _thisScene = 2;

    public static event Action<int> onChallengeStart;

    public static event Action onChallengeComplete;

    public static event Action onGameComplete;

    public static event Action<bool, bool> onDisplayResults;

    public static event Action onIsOnFire;

    #region Initialization
    private void Awake()
    {
        //i need this in awake to initialize the vallue in start
        PinManager.onGameStart += PinManager_onGameStart;
    }

    private void Start()
    {
        BallReturn.onBallCollected += BallReturn_onBallCollected;
        BowlingBall.onBallStop += BowlingBall_onBallStop;
        PinManager.onResultsCalculated += PinManager_onResultsCalculated;
        ExplodingBall.onPinsHit += ExplodingBall_onPinsHit;
        ExplodingBall.onBallStop += ExplodingBall_onBallStop;
        Player.onLoadMainMenu += Player_onLoadMainMenu;
    }

    private void Player_onLoadMainMenu()
    {
        SceneManager.LoadScene(_mainMenuScene);
    }
    #endregion

    #region Event Methods
    private void PinManager_onGameStart(int totalThrows)
    {
        //check how many throws there are in the collectable pins scriptable object to determine when to end the game
        _totalThrows = totalThrows;
    }

    private void ExplodingBall_onBallStop()
    {
        TurnComplete();
    }

    private void ExplodingBall_onPinsHit()
    {
        TurnComplete();
    }

    private void BallReturn_onBallCollected()
    {
        TurnComplete();
    }

    private void BowlingBall_onBallStop()
    {
        TurnComplete();
    }

    private void PinManager_onResultsCalculated(bool isStrike, bool isCollected, bool isRedPinHit, int pinsCollected, int collectableCount, int pinsDown)
    {
        if (isStrike & isCollected & !isRedPinHit)
        {
            //next round
            _objectivesComplete = true;
            _throwCount++;
            _consecutiveThrows++;

            if (_consecutiveThrows == 3)
            {
                _consecutiveThrows = 0;
                onIsOnFire?.Invoke();
            }

            //check if game is won
            if (_throwCount >= _totalThrows)
            {
                _isGameOver = true;
                onGameComplete?.Invoke();
            }
        }
        else
            _consecutiveThrows = 0;

        onDisplayResults?.Invoke(_objectivesComplete, _isGameOver);

        _turnComplete = false;
    }
    #endregion

    #region Public Methods
    //button reference
    public void StartGame()
    {
        //start challenge
        onChallengeStart?.Invoke(_throwCount);
        _objectivesComplete = false;
    }

    //button reference
    public void ReloadScene()
    {
        SceneManager.LoadScene(_thisScene);
    }
    #endregion

    private void TurnComplete()
    {
        if (!_turnComplete)
        {
            //turn complete
            _turnComplete = true;

            //check pins
            onChallengeComplete?.Invoke();
        }
    }

    private void OnDisable()
    {
        BallReturn.onBallCollected -= BallReturn_onBallCollected;
        BowlingBall.onBallStop -= BowlingBall_onBallStop;
        PinManager.onResultsCalculated -= PinManager_onResultsCalculated;
        ExplodingBall.onPinsHit -= ExplodingBall_onPinsHit;
        ExplodingBall.onBallStop -= ExplodingBall_onBallStop;
        PinManager.onGameStart -= PinManager_onGameStart;
        Player.onLoadMainMenu -= Player_onLoadMainMenu;
    }
}
