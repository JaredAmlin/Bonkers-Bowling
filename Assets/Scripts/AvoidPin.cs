using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AvoidPin : MonoBehaviour
{
    private Rigidbody _rb;

    private Vector3 _startingPosition;
    private Quaternion _startingRotation;

    [SerializeField] private AudioSource _hitSource;

    private const string _ballTag = "Ball";

    public static event Action onAvoidPin;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _startingPosition = _rb.position;
        _startingRotation = _rb.rotation;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        PinManager.onResetPins += PinManager_onResetPins;
    }

    private void OnDisable()
    {
        PinManager.onResetPins -= PinManager_onResetPins;
    }

    private void PinManager_onResetPins()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_ballTag))
        {
            _hitSource.Play();
            onAvoidPin?.Invoke();
        }
    }
}
