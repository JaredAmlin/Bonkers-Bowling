using System;
using UnityEngine;

public class PinManagerFreePlay : MonoBehaviour
{
    public static event Action onResetPins;

    private void Start()
    {
        FreePlayPlayer.onResetPins += FreePlayPlayer_onResetPins;
    }
    private void OnDisable()
    {
        FreePlayPlayer.onResetPins -= FreePlayPlayer_onResetPins;
    }

    private void FreePlayPlayer_onResetPins()
    {
        onResetPins?.Invoke();
    }
}
