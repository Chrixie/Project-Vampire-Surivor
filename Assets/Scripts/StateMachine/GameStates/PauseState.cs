using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : State
{
    public override void UpdateState()
    {
        base.UpdateState();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SwitchState<PlayingState>();
        }

    }
}
