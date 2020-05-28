using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("level");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
