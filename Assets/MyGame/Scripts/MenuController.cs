using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static string loadedScene = "MainScene";

    public void Play()
    {
        SceneManager.LoadScene(loadedScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
