using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private PlayerInputActions _input;

    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private AudioSource _soundTrackSource;
    [SerializeField] private float _loadDelayTime = 1.5f;
    private float _timeElapsed;
    private const int _freePlayScene = 1, _gameScene = 2;
    private const string _loadingPanelString = "Loading Panel";

    #region Start / Initialization
    private void Start()
    {
        InitializeInput();

        NullChecks();

        EnableCursor();
    }

    private void InitializeInput()
    {
        //use input system
        _input = new PlayerInputActions();

        if (_input != null)
        {
            _input.Player.Enable();
        }
        else
            Debug.LogWarning("The Player Input is NULL");

        //subscribe to escape key to quit
        _input.Player.Quit.performed += Quit_performed;
    }

    private void NullChecks()
    {
        //check loading panel
        if (_loadingPanel == null)
        {
            _loadingPanel = this.transform.Find(_loadingPanelString).gameObject;
        }

        //check soundtrack source
        if (_soundTrackSource == null & TryGetComponent<AudioSource>(out AudioSource source))
        {
            _soundTrackSource = source;
        }
    }

    private void EnableCursor()
    {
        //activate the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    #endregion

    #region Public Methods
    //button reference
    public void LoadFreePlayScene()
    {
        if (_loadingPanel != null)
            _loadingPanel.SetActive(true);

        if (_soundTrackSource != null)
            //load the free play scene after the music fades out
            StartCoroutine(LoadSceneRoutine(_freePlayScene, _loadDelayTime));
    }

    //button reference
    public void LoadGameScene()
    {
        if (_loadingPanel != null)
            _loadingPanel.SetActive(true);

        if (_soundTrackSource != null)
            //load the game scene scene after the music fades out
            StartCoroutine(LoadSceneRoutine(_gameScene, _loadDelayTime));
    }
    #endregion

    private void OnDisable()
    {
        //unsubscrube from quit 
        _input.Player.Quit.performed -= Quit_performed;
    }

    private void Quit_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        //exit game
        Application.Quit();
    }

    private IEnumerator LoadSceneRoutine(int scene, float audioFadeTime)
    {
        _timeElapsed = 0f;

        while (_timeElapsed < audioFadeTime)
        {
            //fade the soundtrack volume out from one to zero over time
            _soundTrackSource.volume = Mathf.Lerp(1, 0, _timeElapsed / audioFadeTime);
            _timeElapsed += Time.deltaTime;
            yield return null;
        }

        //load scene after volume has faded
        SceneManager.LoadScene(scene);
    }
}
