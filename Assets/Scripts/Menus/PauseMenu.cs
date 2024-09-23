using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : PauseState
{
    public void Resume()
    {
        GameManager.Instance.SwitchState<PlayingState>();
        pauseMenu.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync("GameLevel");
    }
    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        quitMenu.SetActive(false);
    }
    public void OptionsBack()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);

    }
    public void Quit()
    {
        quitMenu.SetActive(true);
    }
    public void QuitMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void QuitQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
