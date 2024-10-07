using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : State
{
    public TMP_Text HighScoreText;

    private void Start()
    {
        int HighScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = "All Time Highscore: " + HighScore.ToString() + " seconds";
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("GameLevel");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
