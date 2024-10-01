using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayingState : State
{
    [SerializeField] Player Player;
    [SerializeField] EnemyMovement Enemy;
    [SerializeField] EnemySpawner EnemySpawner;
    [SerializeField] Bow Bow;

    public override void EnterState()
    {
        base.EnterState();
        Time.timeScale = 1;
    }
    public override void UpdateState()
    {
        base.UpdateState();

        Player.PlayerUpdate();
        Enemy.EnemyMovementUpdate();
        EnemySpawner.SpawnerUpdate();
        Bow.ShootUpdate();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SwitchState<PauseState>();
        }
    }
}
