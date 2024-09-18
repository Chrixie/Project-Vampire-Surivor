using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : State
{
    [SerializeField] Player Player;
    [SerializeField] EnemyMovement Enemy;

    public override void UpdateState()
    {
        base.UpdateState();

        Player.Update();
        Enemy.Update();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SwitchState<PauseState>();
            Debug.Log("Escape");
            print(KeyCode.Escape);
        }

    }
}
