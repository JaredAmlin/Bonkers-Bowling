using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class BowlingBallFreePlay : MonoBehaviour, IThrowable
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _timeToDeactivate = 10f;
    [SerializeField] private AudioSource _ballHitSource;
    [SerializeField] private AudioSource _ballRollSource;
    bool _hasPlayedSFX = false;
    bool _hasPlayedStrikeSFX = false;

    private const string _pinTag = "Pin";

    public static event Action onPinsHit;

    // Start is called before the first frame update
    void Start()
    {
        Init();

        Deactivate();
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

    private void Deactivate()
    {
        //destroy object after elapsed seconds
        Destroy(this.gameObject, _timeToDeactivate);
    }

    public void Throw(Vector3 velocity, Vector3 torqueVelocity)
    {
        if (_rb == null)
            Init();

        _rb.AddForce(velocity, ForceMode.Impulse); ;
        _rb.AddRelativeTorque(torqueVelocity, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasPlayedSFX)
        {
            _hasPlayedSFX = true;

            if (_ballHitSource != null)
                _ballHitSource.Play();

            if (_ballRollSource != null)
                _ballRollSource.Play();
        }

        if (collision.gameObject.CompareTag(_pinTag))
        {
            if (!_hasPlayedStrikeSFX)
            {
                _hasPlayedStrikeSFX = true;

                //audio manager event
                onPinsHit?.Invoke();
            }
        }
    }
}
