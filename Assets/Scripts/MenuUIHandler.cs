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
    public Button startButton;

    private void Start()
    {
        playerNamePrompt = GameObject.Find("Player Name Prompt").GetComponent<TMP_InputField>();
        startButton = GameObject.Find("Start Button").GetComponent<Button>();
        if (GameManager.playerName != null)
        {
            playerNamePrompt.text = GameManager.playerName;
        }
    }

    private void Update()
    {
        startButton.interactable = !playerNamePrompt.placeholder.enabled;
    }


    public void StartNew()
    {
        GameManager.playerName = playerNamePrompt.text;
        SceneManager.LoadScene(1);
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
