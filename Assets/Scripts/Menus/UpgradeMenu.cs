using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : UpgradeState
{

    public void UpgradeOne()
    {
        GameManager.Instance.SwitchState<PlayingState>();
        upgradeMenu.SetActive(false);
    }
    public void UpgradeTwo()
    {
        GameManager.Instance.SwitchState<PlayingState>();
        upgradeMenu.SetActive(false);
    }
    public void UpgradeThree()
    {
        GameManager.Instance.SwitchState<PlayingState>();
        upgradeMenu.SetActive(false);
    }
}
