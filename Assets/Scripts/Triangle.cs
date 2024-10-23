using UnityEngine;

public class Triangle : MonoBehaviour
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

        PinManager.onResetPins += PinManager__onResetPins;
    }

    private void OnDisable()
    {
        PinManager.onResetPins -= PinManager__onResetPins;
    }

    private void PinManager__onResetPins()
    {
        //play animation
        _anim.SetTrigger(_pinReset);
    }
}
