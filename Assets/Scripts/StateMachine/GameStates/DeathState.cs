using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    // Start is called before the first frame update
    [SerializeField] protected GameObject canvasDeathmenu;
    [SerializeField] protected GameObject deathMenu;
    [SerializeField] protected GameObject UpgradecanvasMenu;
    public override void EnterState()
    {
        base.EnterState();
        deathMenu.SetActive(true);
        canvasDeathmenu.SetActive(true);
        UpgradecanvasMenu.SetActive(false);
        Time.timeScale = 0;
        Debug.Log("deathstate");
    }


    public override void UpdateState()
    {
        base.UpdateState();
    }
    public override void ExitState()
    {
        base.ExitState();
        deathMenu.SetActive(false);
        canvasDeathmenu.SetActive(false);

    }
}
