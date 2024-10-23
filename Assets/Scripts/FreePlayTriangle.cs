using UnityEngine;

public class FreePlayTriangle : MonoBehaviour
{
    private Animator _anim;
    private const string _pinReset = "PinReset";

    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<Animator>(out Animator anim))
        {
            _anim = anim;
        }

        PinManagerFreePlay.onResetPins += PinManager__onResetPins;
    }

    private void OnDisable()
    {
        PinManagerFreePlay.onResetPins -= PinManager__onResetPins;
    }

    private void PinManager__onResetPins()
    {
        //play animation
        _anim.SetTrigger(_pinReset);
    }
}
