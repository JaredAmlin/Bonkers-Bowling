using UnityEngine;
using System;

public class Jukebox : MonoBehaviour
{
    private const string _ballTag = "Ball";

    public static event Action onJukeboxHit;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_ballTag))
        {
            //raise event for audio manager
            onJukeboxHit?.Invoke();
        }
    }
}
