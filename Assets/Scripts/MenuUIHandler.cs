using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNamePrompt;
    public TextMeshProUGUI currentHighScore; 
    public Button startButton;

    private void Start()
    {
        playerNamePrompt = GameObject.Find("Player Name Prompt").GetComponent<TMP_InputField>();
        startButton = GameObject.Find("Start Button").GetComponent<Button>();

        if (GameManager.playerName != null)
        {
            SetPlayerName();
        }

            SetHighScoreText();
        
    }

    private void Update()
    {
        startButton.interactable = !playerNamePrompt.placeholder.enabled;
    }

    private void SetPlayerName()
    {
        playerNamePrompt.text = GameManager.playerName;
    }

    private void SetHighScoreText()
    {
        if (GameManager.highScorePoints > 0)
        {
            currentHighScore.text = "High Score: Player: " + GameManager.highScoreName + " Score: " + GameManager.highScorePoints;
        }
        else
        {
            currentHighScore.text = "";
        }
    }

    public void StartNew()
    {
        GameManager.playerName = playerNamePrompt.text;
        SceneManager.LoadScene(1);
    }

    public void ResetHighScores()
    {
        GameManager.highScorePoints = 0;
        GameManager.highScoreName = "";
        SetHighScoreText();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

}
