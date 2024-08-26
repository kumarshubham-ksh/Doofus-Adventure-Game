using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public void PlayGame()
    {
        PlayerPrefs.DeleteKey("CurrentScore");
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        PlayerPrefs.DeleteKey("CurrentScore");
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}