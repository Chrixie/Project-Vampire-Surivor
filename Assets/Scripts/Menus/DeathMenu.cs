using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : DeathState
{
    [SerializeField] protected GameObject restart;
    [SerializeField] protected GameObject mainMenu;
    [SerializeField] protected GameObject quit;
    public void Restart()
    {
        SceneManager.LoadSceneAsync("GameLevel");
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
