using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsBall : MonoBehaviour, IThrowable
{
    [SerializeField] private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        Init();
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
}
