using UnityEngine;
using System;

public class MovingPin : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;
    private const string _ballTag = "Ball";

    [SerializeField] private AudioSource _hitSource;

    public static event Action onAvoidPin;

    // Start is called before the first frame update
    void Start()
    {
        _speed = UnityEngine.Random.Range(0.25f, 1f);

        int randomDirection = UnityEngine.Random.Range(0, 2);

        if (randomDirection == 0)
        {
            _direction = Vector3.right;
        }
        else
            _direction = Vector3.left;

        PinManager.onResetPins += PinManager_onResetPins;
    }

    private void Update()
    {
        //movement
        transform.Translate(_direction * Time.deltaTime * _speed);

        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (transform.position.x > 0.5f)
        {
            //move left
            _direction = Vector3.left;
        }
        else if (transform.position.x < -0.5f)
        {
            //move right
            _direction = Vector3.right;
        }
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
