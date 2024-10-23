using UnityEngine;
using System;

public class BallReturn : MonoBehaviour
{
    private const string _ballTag = "Ball";

    public static event Action onBallCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_ballTag))
        {
            onBallCollected?.Invoke();
            //ball collected
            Destroy(other.gameObject);
        }
    }
}
