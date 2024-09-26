using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : State
{
    [SerializeField] protected GameObject canvasMenu;
    [SerializeField] protected GameObject pauseMenu;
    [SerializeField] protected GameObject optionsMenu;
    [SerializeField] protected GameObject quitMenu;
    public override void EnterState()
    {
        base.EnterState();
        pauseMenu.SetActive(true);
        canvasMenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("pausestate");
    }


    public override void UpdateState()
    {
        base.UpdateState();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SwitchState<PlayingState>();
        }
    }
    public override void ExitState() { 
        base.ExitState();
        canvasMenu.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);

    }
}
