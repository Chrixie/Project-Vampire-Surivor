using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : State
{
    [SerializeField] GameObject PauseMenu;
    public override void EnterState()
    {
        base.EnterState();
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }


    public override void UpdateState()
    {
        base.UpdateState();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SwitchState<PlayingState>();
        }
    }



}
