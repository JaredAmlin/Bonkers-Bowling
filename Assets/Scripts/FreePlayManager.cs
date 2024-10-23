using UnityEngine;
using UnityEngine.SceneManagement;

public class FreePlayManager : MonoBehaviour
{
    private void Start()
    {
        FreePlayPlayer.onLoadMainMenu += FreePlayPlayer_onLoadMainMenu;
    }

    private void OnDisable()
    {
        FreePlayPlayer.onLoadMainMenu -= FreePlayPlayer_onLoadMainMenu;
    }

    private void FreePlayPlayer_onLoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
