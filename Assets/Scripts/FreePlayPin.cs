using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FreePlayPin : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _startingPosition;
    private Quaternion _startingRotation;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _startingPosition = _rb.position;
        _startingRotation = _rb.rotation;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        PinManagerFreePlay.onResetPins += PinManagerFreePlay_onResetPins;
    }

    private void PinManagerFreePlay_onResetPins()
    {
        _rb.position = _startingPosition;
        _rb.rotation = _startingRotation;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    private void OnDisable()
    {
        PinManagerFreePlay.onResetPins -= PinManagerFreePlay_onResetPins;
    }
}
