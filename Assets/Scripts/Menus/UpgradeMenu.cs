using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : UpgradeState
{
    [SerializeField] protected GameObject upgradeOne;
    [SerializeField] protected GameObject upgradeTwo;
    [SerializeField] protected GameObject upgradeThree;
    public void UpgradeOne()
    {
        GameManager.Instance.SwitchState<PlayingState>();
        upgradeMenu.SetActive(false);
        canvasMenu.SetActive(false);
    }
    public void UpgradeTwo()
    {
        GameManager.Instance.SwitchState<PlayingState>();
        upgradeMenu.SetActive(false);
        canvasMenu.SetActive(false);
    }
    public void UpgradeThree()
    {
        GameManager.Instance.SwitchState<PlayingState>();

    }
}
