using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainUIHandler : MonoBehaviour
{
    private GameObject PauseUI;
    private float pauseTime = 0.0f;
    private float defaultTime = 1.0f;

    private void Start()
    {
        PauseUI = GameObject.Find("Pause UI");
        PauseUI.SetActive(GameManager.isGamePaused);
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
        PauseUI.SetActive(GameManager.isGamePaused);
    }
}
