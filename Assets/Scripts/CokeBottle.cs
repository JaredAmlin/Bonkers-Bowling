using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CokeBottle : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _force = 10f;
    private float _startingForce;

    private bool _isHit = false;

    [SerializeField] private ParticleSystem _cokeVFX;

    private Vector3 _rotationDirection = new Vector3(1, 0, 1);

    private const string _ballTag = "Ball";

    private WaitForFixedUpdate _waitForFixedUpdate;

    // Start is called before the first frame update
    void Start()
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

        if (_cokeVFX == null)
            _cokeVFX = GetComponentInChildren<ParticleSystem>();

        _startingForce = _force;

        _waitForFixedUpdate = new WaitForFixedUpdate();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_ballTag))
        {
            _isHit = true;

            if (_cokeVFX != null)
                _cokeVFX.Play();

            StartCoroutine(SodaRoutine());
        }
    }

    private IEnumerator SodaRoutine()
    {
        while(_isHit)
        {
            _rb.AddRelativeForce(Vector3.down * _force, ForceMode.Force);
            _rb.AddRelativeTorque(_rotationDirection * 0.1f, ForceMode.Force);
             
            _force -= 0.01f;

            if (_force < 0)
            {
                _isHit = false;
            }
            yield return _waitForFixedUpdate;
        }

        _force = _startingForce;

        if (_cokeVFX != null)
            _cokeVFX.Stop();
    }
}
