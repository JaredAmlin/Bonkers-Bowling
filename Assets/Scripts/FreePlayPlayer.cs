using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class FreePlayPlayer : MonoBehaviour
{
    #region Variables
    private PlayerInputActions _input;

    private CharacterController _controller;

    [Header("Manager Classes")]
    [SerializeField] private PhysicsSimulation _physicsSimulation;
    [SerializeField] private FreePlayUIManager _UIManager;

    private Vector2 _direction;
    private Vector2 _aimDirection;

    [Header("Move and Look Speeds")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _lookSensitivity = 5.0f;

    [SerializeField] private Camera _fpsCamera;
    private Vector3 _initialCameraPos;

    [Header("Bowling Balls")]
    [SerializeField] private GameObject[] _balls;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _defaultForce = 40f;
    [SerializeField] private float _torque;
    [SerializeField] private float _zRotMin;
    [SerializeField] private float _zRotMax;
    private float _zRotation; //controls the left or right spin on the ball
    private float _force;
    private float _xRotation; //controls the back or forward spin on the ball
    private Vector3 _rotationDirection;
    private GameObject _ball;
    private int _ballIndex;

    [Header("UI Balls")]
    [SerializeField] private GameObject _blueUIBall;
    [SerializeField] private GameObject _lavaUIBall;

    [Header("Torque Input Sensitivity")]
    [SerializeField] private float _torqueIncrementValue;
    [SerializeField] private float _forceIncrementValue;
    [SerializeField] private int _maxForce;
    [SerializeField] private int _minForce;

    private Vector3 _velocity;
    private Vector3 _torqueVelocity;

    private Vector3 _moveDirection;
    private Vector3 _moveVelocity;
    private Vector3 _lookDirection;
    private Vector3 _cameraRotation;
    private Vector3 _vector3right = Vector3.right;
    private Vector3 _vector3up = Vector3.up;

    private float _torqueInput;
    private float _forceInput;
    private Vector3 _finalTorqueDirection;

    private bool _isSimulationRunning = false;
    private bool _isThrowCanceled = false;
    private bool _isBackSpin = false;

    public static event Action onLoadMainMenu;
    public static event Action onResetPins;

    private const string _lavaBallUITag = "LavaBallUI";
    private const string _blueBallUITag = "BlueBallUI";
    private const string _firePointTag = "FirePoint";
    private const string _blueBallFreePlayTag = "BlueBallFreePlay";
    private const string _lavaBallFreePlayTag = "LavaBallFreePlay";
    #endregion

    #region Initialization
    private void Start()
    {
        NullChecks();

        InputInitialization();

        _force = _defaultForce;

        if (_lavaUIBall != null)
            _lavaUIBall.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void NullChecks()
    {
        if (TryGetComponent<CharacterController>(out CharacterController controller))
        {
            _controller = controller;
        }

        if (_fpsCamera == null)
        {
            _fpsCamera = GetComponentInChildren<Camera>();
        }

        if (_fpsCamera != null)
            _initialCameraPos = _fpsCamera.transform.localPosition;

        if (_physicsSimulation == null)
            _physicsSimulation = FindObjectOfType<PhysicsSimulation>();

        if (_UIManager == null)
            _UIManager = FindObjectOfType<FreePlayUIManager>();

        if (_firePoint == null)
        {
            Transform firePoint = GameObject.FindGameObjectWithTag(_firePointTag).transform;

            if (firePoint != null)
                _firePoint = firePoint;
        }

        if (_balls.Length == 0)
        {
            GameObject blueBall = Resources.Load<GameObject>(_blueBallFreePlayTag);
            GameObject lavaBall = Resources.Load<GameObject>(_lavaBallFreePlayTag);

            _balls = new GameObject[] { blueBall, lavaBall };
        }

        if (_blueUIBall == null)
        {
            GameObject blueBallUI = GameObject.FindGameObjectWithTag(_blueBallUITag);

            if (blueBallUI != null)
                _blueUIBall = blueBallUI;
        }

        if (_lavaUIBall == null)
        {
            GameObject lavaBallUI = GameObject.FindGameObjectWithTag(_lavaBallUITag);

            if (lavaBallUI != null)
            {
                _lavaUIBall = lavaBallUI;
            }
        }
    }

    private void InputInitialization()
    {
        _input = new PlayerInputActions();

        if (_input != null)
        {
            _input.Player.Enable();
        }
        else
            Debug.LogWarning("The Player Input is NULL");

        _input.Player.Throw.performed += Throw_performed;
        _input.Player.Throw.canceled += Throw_canceled;
        _input.Player.CancelThrow.performed += CancelThrow_performed;
        _input.Player.ResetPins.performed += ResetPins_performed;
        _input.Player.ResetAim.performed += ResetAim_performed;
        _input.Player.BackSpin.performed += BackSpin_performed;
        _input.Player.Controls.performed += Controls_performed;
        _input.Player.LoadMainMenu.performed += LoadMainMenu_performed;
        _input.Player.SwitchBall.performed += SwitchBall_performed;
        _input.Player.Quit.performed += Quit_performed;
    }
    #endregion

    #region Event Methods
    private void Quit_performed(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    private void SwitchBall_performed(InputAction.CallbackContext context)
    {
        //switch ball
        _ballIndex++;

        if (_ballIndex > _balls.Length - 1)
        {
            _ballIndex = 0;
        }

        if (_ballIndex == 0)
        {
            _blueUIBall.SetActive(true);
            _lavaUIBall.SetActive(false);
        }
        else
        {
            _blueUIBall.SetActive(false);
            _lavaUIBall.SetActive(true);
        }

        _UIManager.SwitchBallUI(_ballIndex);
    }

    private void LoadMainMenu_performed(InputAction.CallbackContext context)
    {
        //load main menu
        onLoadMainMenu?.Invoke();
    }

    private void Controls_performed(InputAction.CallbackContext context)
    {
        //toggle controls panel on and off
        _UIManager.ToggleControlsPanel();
    }

    private void BackSpin_performed(InputAction.CallbackContext context)
    {
        if (_isBackSpin)
        {
            _isBackSpin = false;
            _xRotation = 0f;
        }
        else
        {
            _isBackSpin = true;
            _xRotation = -1f;
        }

        _UIManager.ToggleBackSpinUI(_isBackSpin);
    }

    private void ResetAim_performed(InputAction.CallbackContext context)
    {
        //reset Z rotation and force to default
        _force = _defaultForce;
        
        _zRotation = 0f;

        if (_isBackSpin)
        {
            _isBackSpin = false;
            _xRotation = 0f;
            _UIManager.ToggleBackSpinUI(_isBackSpin);
        }
    }

    private void ResetPins_performed(InputAction.CallbackContext context)
    {
        //pin reset event
        onResetPins?.Invoke();
    }

    private void CancelThrow_performed(InputAction.CallbackContext context)
    {
        //cancel throw
        _isThrowCanceled = true;

        StopPhysicsSimulation();
    }

    private void Throw_canceled(InputAction.CallbackContext context)
    {
        StopPhysicsSimulation();

        if (_isThrowCanceled == false)
        {
            Throw();
        }
    }

    private void Throw_performed(InputAction.CallbackContext context)
    {
        //start physics simulation on left-click
        _isSimulationRunning = true;

        _isThrowCanceled = false;
    }
    #endregion

    #region Update / Fixed Update
    private void Update()
    {
        Movement();
        Rotate();
        TorqueInput();
        ForceInput();
    }

    private void FixedUpdate()
    {
        if (_isSimulationRunning)
        {
            _velocity = _firePoint.forward * _force;
            _torqueVelocity = _rotationDirection * _torque;
            _physicsSimulation.SimulateTrajectory(_firePoint.transform.position, _velocity, _torqueVelocity);
        }
    }
    #endregion

    #region Private Methods
    private void Movement()
    {
        _direction = _input.Player.Move.ReadValue<Vector2>();

        _moveDirection = new Vector3(_direction.x, 0, _direction.y);

        _moveVelocity = (_moveDirection * Time.deltaTime * _moveSpeed);

        _moveVelocity = transform.TransformDirection(_moveVelocity);

        _controller.Move(_moveVelocity);
    }

    private void Rotate()
    {
        _aimDirection = _input.Player.Rotate.ReadValue<Vector2>();

        _lookDirection = transform.localEulerAngles;

        _lookDirection.y += _aimDirection.x * _lookSensitivity;

        transform.localRotation = Quaternion.AngleAxis(_lookDirection.y, _vector3up);

        _cameraRotation = _fpsCamera.transform.localEulerAngles;

        _cameraRotation.x += -_aimDirection.y * _lookSensitivity;

        _fpsCamera.transform.localRotation = Quaternion.AngleAxis(_cameraRotation.x, _vector3right);
    }

    private void TorqueInput()
    {
        _torqueInput = _input.Player.TorqueDirection.ReadValue<float>();
        _forceInput = _input.Player.Force.ReadValue<float>();

        if (_torqueInput > 0)
        {
            _zRotation += _torqueIncrementValue;
        }
        else if (_torqueInput < 0)
        {
            _zRotation -= _torqueIncrementValue;
        }

        _zRotation = Mathf.Clamp(_zRotation, _zRotMin, _zRotMax);
    }

    private void ForceInput()
    {
        if (_forceInput > 0)
        {
            _force += _forceIncrementValue;
        }
        else if (_forceInput < 0)
        {
            _force -= _forceIncrementValue;
        }

        _force = Mathf.Clamp(_force, _minForce, _maxForce);

        _UIManager.UpdatePowerUI(_force, _maxForce);

        _finalTorqueDirection = new Vector3(_xRotation, 0, _zRotation);

        _rotationDirection = _finalTorqueDirection;
    }

    private void Throw()
    {
        _ball = Instantiate(_balls[_ballIndex], _firePoint.position, Quaternion.identity);

        //check for IThrowable interface
        IThrowable throwable = _ball.GetComponent<IThrowable>();

        //calculate velocity and torque velocity
        _velocity = _firePoint.forward * _force;
        _torqueVelocity = _rotationDirection * _torque;

        if (throwable != null)
            throwable.Throw(_velocity, _torqueVelocity);
    }

    private void StopPhysicsSimulation()
    {
        //stop physics simulation and throw on left-click release
        _isSimulationRunning = false;
        //tell physics simulation to stop running line renderer
        _physicsSimulation.StopLine();
    }
    #endregion

    private void OnDisable()
    {
        _input.Player.Throw.performed -= Throw_performed;
        _input.Player.Throw.canceled -= Throw_canceled;
        _input.Player.CancelThrow.performed -= CancelThrow_performed;
        _input.Player.ResetPins.performed -= ResetPins_performed;
        _input.Player.ResetAim.performed -= ResetAim_performed;
        _input.Player.BackSpin.performed -= BackSpin_performed;
        _input.Player.Controls.performed -= Controls_performed;
        _input.Player.LoadMainMenu.performed -= LoadMainMenu_performed;
        _input.Player.SwitchBall.performed -= SwitchBall_performed;
        _input.Player.Quit.performed += Quit_performed;
    }
}
