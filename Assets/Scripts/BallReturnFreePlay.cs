using UnityEngine;

public class BallReturnFreePlay : MonoBehaviour
{
    private const string _ballTag = "Ball";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_ballTag))
            Destroy(other.gameObject);
    }
}
