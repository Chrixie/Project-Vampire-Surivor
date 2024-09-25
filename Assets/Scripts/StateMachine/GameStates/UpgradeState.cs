using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeState : State
{
    [SerializeField] protected GameObject upgradeOne;
    [SerializeField] protected GameObject upgradeTwo;
    [SerializeField] protected GameObject upgradeThree;
    [SerializeField] protected GameObject upgradeMenu;

    public override void EnterState()
    {
        base.EnterState();
        upgradeMenu.SetActive(true);
        Time.timeScale = 0;
    }


    public override void UpdateState()
    {
        base.UpdateState();

    }
    public override void ExitState()
    {
        base.ExitState();

    }
}