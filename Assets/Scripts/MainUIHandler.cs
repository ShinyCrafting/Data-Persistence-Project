using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
#endif

public class MainUIHandler : MonoBehaviour
{
    private GameObject pauseUI;

    private float pauseTime = 0.0f;
    private float defaultTime = 1.0f;

    private void Start()
    {
        pauseUI = GameObject.Find("Pause UI");
        pauseUI.SetActive(GameManager.isGamePaused);
    }
    public void ToMainMenu()
    {
        if (GameManager.isGamePaused)
            PauseGame();
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        GameManager.isGamePaused = !GameManager.isGamePaused;
        if (GameManager.isGamePaused)
        {
            Time.timeScale = pauseTime;
        }
        else if (!GameManager.isGamePaused)
        {
            Time.timeScale = defaultTime;
        }
        pauseUI.SetActive(GameManager.isGamePaused);
    }
}
