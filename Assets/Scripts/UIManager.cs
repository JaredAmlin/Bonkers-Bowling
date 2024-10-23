using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Variables
    [Header("Ball Panel")]
    [SerializeField] private Image _powerFillImage;
    [SerializeField] private Color _minPowerColor;
    [SerializeField] private Color _maxPowerColor;
    [SerializeField] private Image _ballMask;
    [SerializeField] private Image _backSpinImage;
    [SerializeField] private Image _blueBallImage;
    [SerializeField] private Image _lavaBallImage;

    [Header("UI Panels")]
    [SerializeField] private GameObject _controlsPanel;
    [SerializeField] private GameObject _statsPanel;
    [SerializeField] private GameObject _objectivesPanel;

    [Header("Buttons")]
    [SerializeField] private GameObject _startGameButton;
    [SerializeField] private GameObject _tryAgainButton;
    [SerializeField] private GameObject _nextThrowButton;
    [SerializeField] private GameObject _replayButton;

    [Header("Star Images")]
    [SerializeField] private Image _collectableStar, _strikeStar, _avoidStar;

    [Header("UI Texts")]
    [SerializeField] private TMP_Text _throwText;
    [SerializeField] private TMP_Text _pinsCollectedText;
    [SerializeField] private TMP_Text _pinsDownText;

    [Header("Text Objects")]
    [SerializeField] private GameObject _strikeText;
    [SerializeField] private GameObject _waitingForPins;
    [SerializeField] private GameObject _gameWinText;

    [Header("Text Colors")]
    [SerializeField] private Color _completeColor;
    private Color _red = Color.red;
 
    private const string _throwString = "Throw ";
    private const string _powerFillTag = "PowerFill";
    private const string _backSpinImageTag = "BackSpinImage";
    private const string _blueBallImageTag = "BlueBallImage";
    private const string _lavaBallImageTag = "LavaBallImage";
    private const string _ballMaskTag = "BallMask";
    private const string _controlsPanelTag = "ControlsPanel";
    private const string _statsPanelTag = "StatsPanel";
    private const string _objectivesPanelTag = "ObjectivesPanel";
    private const string _startButtonTag = "StartButton";
    private const string _tryAgainButtonTag = "TryAgain";
    private const string _nextThrowButtonTag = "NextThrow";
    private const string _replayButtonTag = "Replay";
    private const string _collectableStarTag = "CollectableStar";
    private const string _strikeStarStarTag = "StrikeStar";
    private const string _avoidStarTag = "AvoidStar";
    private const string _throwTextTag = "ThrowText";
    private const string _pinsCollectedTextTag = "PinsCollected";
    private const string _pinsDownTextTag = "PinsDown";
    private const string _strikeTextTag = "Strike";
    private const string _waitingForPinsTextTag = "WaitingForPins";
    private const string _gameWinTextTag = "GameWin";
    private const int _tenPin = 10;
    #endregion

    #region Initialization
    private void Start()
    {
        NullChecks();

        DeactivateStartingUI();

        GameManager.onChallengeStart += GameManager_onChallengeStart;
        GameManager.onDisplayResults += GameManager_onDisplayResults;
        GameManager.onChallengeComplete += GameManager_onChallengeComplete;
        PinManager.onResultsCalculated += PinManager_onResultsCalculated;
    }

    private void NullChecks()
    {
        if (_powerFillImage == null)
        {
            GameObject powerFill = GameObject.FindGameObjectWithTag(_powerFillTag);

            if (powerFill != null)
            {
                _powerFillImage = powerFill.GetComponent<Image>();
            }
        }

        if (_backSpinImage == null)
        {
            GameObject backSpinImg = GameObject.FindGameObjectWithTag(_backSpinImageTag);

            if (backSpinImg != null)
            {
                _backSpinImage = backSpinImg.GetComponent<Image>();
            }
        }

        if (_blueBallImage == null)
        {
            GameObject blueBallImg = GameObject.FindGameObjectWithTag(_blueBallImageTag);

            if (blueBallImg != null)
            {
                _blueBallImage = blueBallImg.GetComponent<Image>();
            }
        }

        if (_lavaBallImage == null)
        {
            GameObject lavaBallImg = GameObject.FindGameObjectWithTag(_lavaBallImageTag);

            if (lavaBallImg != null)
            {
                _lavaBallImage = lavaBallImg.GetComponent<Image>();
            }
        }

        if (_ballMask == null)
        {
            GameObject ballMaskImage = GameObject.FindGameObjectWithTag(_ballMaskTag);

            if (ballMaskImage != null)
            {
                _ballMask = ballMaskImage.GetComponent<Image>();
            }
        }

        if (_controlsPanel == null)
        {
            GameObject controlsPanelObj = GameObject.FindGameObjectWithTag(_controlsPanelTag);

            if (controlsPanelObj != null)
            {
                _controlsPanel = controlsPanelObj;
            }
        }

        if (_statsPanel == null)
        {
            GameObject statsPanelObj = GameObject.FindGameObjectWithTag(_statsPanelTag);

            if (statsPanelObj != null)
            {
                _statsPanel = statsPanelObj;
            }
        }

        if (_objectivesPanel == null)
        {
            GameObject objectivesPanelObj = GameObject.FindGameObjectWithTag(_objectivesPanelTag);

            if (objectivesPanelObj != null)
            {
                _objectivesPanel = objectivesPanelObj;
            }
        }

        if (_startGameButton == null)
        {
            GameObject startGameButton = GameObject.FindGameObjectWithTag(_startButtonTag);

            if (startGameButton != null)
            {
                _startGameButton = startGameButton;
            }
        }

        if (_tryAgainButton == null)
        {
            GameObject tryAgainButton = GameObject.FindGameObjectWithTag(_tryAgainButtonTag);

            if (tryAgainButton != null)
            {
                _tryAgainButton = tryAgainButton;
            }
        }

        if (_nextThrowButton == null)
        {
            GameObject nextThrowButton = GameObject.FindGameObjectWithTag(_nextThrowButtonTag);

            if (nextThrowButton != null)
            {
                _nextThrowButton = nextThrowButton;
            }
        }

        if (_replayButton == null)
        {
            GameObject replayButton = GameObject.FindGameObjectWithTag(_replayButtonTag);

            if (replayButton != null)
            {
                _replayButton = replayButton;
            }
        }

        if (_collectableStar == null)
        {
            GameObject collectableStarImage = GameObject.FindGameObjectWithTag(_collectableStarTag);

            if (collectableStarImage != null)
            {
                _collectableStar = collectableStarImage.GetComponent<Image>();
            }
        }

        if (_strikeStar == null)
        {
            GameObject strikeStarImage = GameObject.FindGameObjectWithTag(_strikeStarStarTag);

            if (strikeStarImage != null)
            {
                _strikeStar = strikeStarImage.GetComponent<Image>();
            }
        }

        if (_avoidStar == null)
        {
            GameObject avoidStarImage = GameObject.FindGameObjectWithTag(_avoidStarTag);

            if (avoidStarImage != null)
            {
                _avoidStar = avoidStarImage.GetComponent<Image>();
            }
        }

        if (_throwText == null)
        {
            GameObject throwTextText = GameObject.FindGameObjectWithTag(_throwTextTag);

            if (throwTextText != null)
            {
                _throwText = throwTextText.GetComponent<TMP_Text>();
            }
        }

        if (_pinsCollectedText == null)
        {
            GameObject pinsCollectedText = GameObject.FindGameObjectWithTag(_pinsCollectedTextTag);

            if (pinsCollectedText != null)
            {
                _pinsCollectedText = pinsCollectedText.GetComponent<TMP_Text>();
            }
        }

        if (_pinsDownText == null)
        {
            GameObject pinsDownText = GameObject.FindGameObjectWithTag(_pinsDownTextTag);

            if (pinsDownText != null)
            {
                _pinsDownText = pinsDownText.GetComponent<TMP_Text>();
            }
        }

        if (_strikeText == null)
        {
            GameObject strikeTextObj = GameObject.FindGameObjectWithTag(_strikeTextTag);

            if (strikeTextObj != null)
            {
                _strikeText = strikeTextObj;
            }
        }

        if (_waitingForPins == null)
        {
            GameObject waitingForPinsTextObj = GameObject.FindGameObjectWithTag(_waitingForPinsTextTag);

            if (waitingForPinsTextObj != null)
            {
                _waitingForPins = waitingForPinsTextObj;
            }
        }

        if (_gameWinText == null)
        {
            GameObject gameWinTextObj = GameObject.FindGameObjectWithTag(_gameWinTextTag);

            if (gameWinTextObj != null)
            {
                _gameWinText = gameWinTextObj;
            }
        }
    }

    private void DeactivateStartingUI()
    {
        _backSpinImage.gameObject.SetActive(false);
        _controlsPanel.SetActive(false);
        _waitingForPins.SetActive(false);
        _strikeText.SetActive(false);
        _collectableStar.gameObject.SetActive(false);
        _strikeStar.gameObject.SetActive(false);
        _avoidStar.gameObject.SetActive(false);
        _statsPanel.SetActive(false);
        _throwText.gameObject.SetActive(false);
        _gameWinText.SetActive(false);
        _nextThrowButton.SetActive(false);
        _tryAgainButton.SetActive(false);
        _replayButton.SetActive(false);
        _lavaBallImage.enabled = false;
    }
    #endregion

    #region Event Methods
    private void PinManager_onResultsCalculated(bool isStrike, bool isCollected, bool isRedPinHit, int pinsCollected, int collectableCount, int pinsDown)
    {
        //enable stats panel
        _statsPanel.SetActive(true);

        //pins collected
        _pinsCollectedText.text = (pinsCollected.ToString() + " / " + collectableCount.ToString());
        //pins down
        _pinsDownText.text = (pinsDown.ToString() + " / " + _tenPin.ToString());

        if (isCollected)
        {
            _pinsCollectedText.color = _completeColor;
            _collectableStar.gameObject.SetActive(true);
        }
        else
            _pinsCollectedText.color = _red;

        if (isStrike)
        {
            _strikeText.SetActive(true);
            _pinsDownText.color = _completeColor;
            _strikeStar.gameObject.SetActive(true);
        }
        else
            _pinsDownText.color = _red;

        if (!isRedPinHit)
        {
            _avoidStar.gameObject.SetActive(true);
        } 
    }

    private void GameManager_onChallengeComplete()
    {
        _waitingForPins.SetActive(true);
    }

    private void GameManager_onDisplayResults(bool objectivesComplete, bool isGameOver)
    {
        _throwText.gameObject.SetActive(false);
        _waitingForPins.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (isGameOver)
        {
            //activate replay button to reload scene
            _gameWinText.SetActive(true);
            _replayButton.SetActive(true);
        }
        else if (objectivesComplete)
        {
            _nextThrowButton.SetActive(true);
        }
        else
            _tryAgainButton.SetActive(true);
    }

    private void GameManager_onChallengeStart(int throwCount)
    {
        _startGameButton.SetActive(false);

        _strikeText.SetActive(false);
        _collectableStar.gameObject.SetActive(false);
        _strikeStar.gameObject.SetActive(false);
        _avoidStar.gameObject.SetActive(false);
        _statsPanel.SetActive(false);

        _throwText.gameObject.SetActive(true);
        _throwText.text = (_throwString + (throwCount + 1));

        _nextThrowButton.SetActive(false);
        _tryAgainButton.SetActive(false);

        if (_objectivesPanel.activeInHierarchy)
            _objectivesPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    #endregion

    #region Public Methods
    public void UpdatePowerUI(float force, float maxForce)
    {
        _powerFillImage.fillAmount = force / maxForce;

        _powerFillImage.color = Color.Lerp(_minPowerColor, _maxPowerColor, _powerFillImage.fillAmount);
    }

    public void ToggleBackSpinUI(bool isBackSpin)
    {
        if (isBackSpin)
        {
            _backSpinImage.gameObject.SetActive(true);
        }
        else
            _backSpinImage.gameObject.SetActive(false);
    }

    public void ToggleControlsPanel()
    {
        if (_controlsPanel.activeInHierarchy == false)
        {
            _controlsPanel.SetActive(true);
        }
        else
            _controlsPanel.SetActive(false);
    }

    public void SwitchBallUI(int ballIndex)
    {
        if (ballIndex == 0)
        {
            _blueBallImage.enabled = true;
            _lavaBallImage.enabled = false;
        }
        else
        {
            _blueBallImage.enabled = false;
            _lavaBallImage.enabled = true;
        }
    }

    public void ToggleBallMask(bool canThrow)
    {
        if (canThrow)
        {
            _ballMask.gameObject.SetActive(false);
        }
        else
            _ballMask.gameObject.SetActive(true);
    }
    #endregion

    private void OnDisable()
    {
        GameManager.onChallengeStart -= GameManager_onChallengeStart;
        GameManager.onDisplayResults -= GameManager_onDisplayResults; 
        GameManager.onChallengeComplete -= GameManager_onChallengeComplete;
        PinManager.onResultsCalculated -= PinManager_onResultsCalculated;
    }
}
