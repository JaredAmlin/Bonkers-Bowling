using System.Collections;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class BowlingBall : MonoBehaviour, IThrowable
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _minVelocity = 0.1f;
    private float _redPinHitVelocity = 0.5f;

    [SerializeField] private AudioSource _ballHitSource;
    [SerializeField] private AudioSource _ballRollSource;
    bool _hasPlayedSFX = false;
    bool _hasPlayedStrikeSFX = false;

    private const string _physicsObjectTag = "PhysicsObject";
    private const string _pinTag = "Pin";
    private const string _redPinTag = "Red Pin";

    private bool _throwAgain = false;

    private WaitForSeconds _velocityCheckTime = new WaitForSeconds(1f);

    public static event Action onBallStop;

    public static event Action onEnvironmentThrow;

    public static event Action onPinsHit;

    // Start is called before the first frame update
    void Start()
    {
        Init();

        StartCoroutine(VelocityCheck());
    }

    private void Init()
    {
        //null check / get Rigidbody component
        if (_rb == null & TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            _rb = rb;
        }
        else if (_rb == null)
        {
            Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
            _rb = rigidbody;
        }
    }

    public void Throw(Vector3 velocity, Vector3 torqueVelocity)
    {
        if (_rb == null)
            Init();

        //uncomment to add upwards force
        //_velocity += new Vector3(0, 10, 0);

        _rb.AddForce(velocity, ForceMode.Impulse); ;
        _rb.AddRelativeTorque(torqueVelocity, ForceMode.Impulse);
    }

    private IEnumerator VelocityCheck()
    {
        while(true)
        {
            yield return _velocityCheckTime;

            if (_rb.velocity.sqrMagnitude < _minVelocity)
            {
                if (!_throwAgain)
                {
                    onBallStop?.Invoke();
                }
                
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_hasPlayedSFX)
        {
            _hasPlayedSFX = true;

            _ballHitSource.Play();

            _ballRollSource.Play();
        }

        if (other.gameObject.CompareTag(_pinTag))
        {
            if (!_hasPlayedStrikeSFX)
            {
                _hasPlayedStrikeSFX = true;

                //audio manager event
                onPinsHit?.Invoke();
            }
        }

        if (other.gameObject.CompareTag(_redPinTag))
            _minVelocity = _redPinHitVelocity;

        if (other.gameObject.CompareTag(_physicsObjectTag) & !_throwAgain)
        {
            //throw again
            _throwAgain = true;

            onEnvironmentThrow?.Invoke();
        }
    }
}
