using UnityEngine;
using UnityEngine.UI;

public class FreePlayUIManager : MonoBehaviour
{
    [SerializeField] private Image _powerFillImage;
    [SerializeField] private Color _minPowerColor;
    [SerializeField] private Color _maxPowerColor;

    [SerializeField] private Image _backSpinImage;
    [SerializeField] private Image _blueBallImage;
    [SerializeField] private Image _lavaBallImage;

    [SerializeField] private GameObject _controlsPanel;

    private const string _powerFillTag = "PowerFill";
    private const string _backSpinImageTag = "BackSpinImage";
    private const string _blueBallImageTag = "BlueBallImage";
    private const string _lavaBallImageTag = "LavaBallImage";
    private const string _controlsPanelTag = "ControlsPanel";

    private void Start()
    {
        NullChecks();

        DeactivateStartingUI();
    }

    #region Initialization
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

        if (_controlsPanel == null)
        {
            GameObject controlsPanelObj = GameObject.FindGameObjectWithTag(_controlsPanelTag);

            if (controlsPanelObj != null)
            {
                _controlsPanel = controlsPanelObj;
            }
        }
    }

    private void DeactivateStartingUI()
    {
        if (_controlsPanel != null)
            _controlsPanel.SetActive(false);

        if (_backSpinImage != null)
            _backSpinImage.gameObject.SetActive(false);

        if (_lavaBallImage != null)
            _lavaBallImage.enabled = false;
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
    #endregion
}
