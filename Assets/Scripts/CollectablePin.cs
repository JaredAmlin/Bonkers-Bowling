using System;
using UnityEngine;

public class CollectablePin : MonoBehaviour
{
    private const string _ballTag = "Ball";

    public static event Action onCollectablePin;

    private void Start()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_ballTag))
        {
            //tell Pin Manager that Red Pin has been HIT
            onCollectablePin?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
