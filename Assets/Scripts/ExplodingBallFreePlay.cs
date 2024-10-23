using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class ExplodingBallFreePlay : MonoBehaviour, IThrowable
{
    #region Variables
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _timeToDeactivate = 10f;
    [SerializeField] private AudioSource _ballHitSource;
    [SerializeField] private AudioSource _ballRollSource;
    bool _hasPlayedSFX = false;
    bool _hasPlayedStrikeSFX = false;

    [Header("Explosion Values")]
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _upwardsModifier = 3f;
    [SerializeField] private GameObject _explosionFX;
    private Vector3 _explosionPosition;
    private Collider[] _colliders;

    private const string _physicsObjectTag = "PhysicsObject";
    private const string _pinTag = "Pin";
    private const string _wallColliderName = "Wall Collider";
    private const string _floorColliderName = "Floor Collider";

    public static event Action onExplosion;
    public static event Action onPinsHit;
    #endregion

    #region Initialization
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
    #endregion

    #region Methods
    private void Deactivate()
    {
        //destroy object after elapsed seconds
        Destroy(this.gameObject, _timeToDeactivate);
    }

    private void Explode()
    {
        _explosionPosition = this.transform.position;

        _colliders = Physics.OverlapSphere(_explosionPosition, _explosionRadius);

        foreach (Collider hit in _colliders)
        {
            if (hit.TryGetComponent(out Rigidbody rb))

                if (rb != null)
                    rb.AddExplosionForce(_explosionForce, _explosionPosition, _explosionRadius, _upwardsModifier, ForceMode.Impulse);
        }

        //instantiate explosion particle FX
        Instantiate(_explosionFX, this.transform.position, Quaternion.identity);

        onExplosion?.Invoke();

        Destroy(this.gameObject);
    }

    public void Throw(Vector3 velocity, Vector3 torqueVelocity)
    {
        if (_rb == null)
            Init();

        _rb.AddForce(velocity, ForceMode.Impulse); ;
        _rb.AddRelativeTorque(torqueVelocity, ForceMode.Impulse);
    }
    #endregion

    #region Collision
    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasPlayedSFX)
        {
            _hasPlayedSFX = true;

            _ballHitSource.Play();

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

            Explode();
        }

        if (collision.gameObject.CompareTag(_physicsObjectTag) | collision.gameObject.CompareTag(_pinTag))
        {
            if (collision.gameObject.name == _floorColliderName | collision.gameObject.name == _wallColliderName)
                return;

            Explode();
        }
    }
    #endregion
}
