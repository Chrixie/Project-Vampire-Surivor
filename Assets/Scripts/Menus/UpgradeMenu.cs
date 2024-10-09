using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : UpgradeState
{
    [SerializeField] protected GameObject upgradeOne;
    [SerializeField] protected GameObject upgradeTwo;
    [SerializeField] protected GameObject upgradeThree;
    [SerializeField] Player Player;
    [SerializeField] Weapon WeaponDamage;
    [SerializeField] Bow ShootSpeed;
    public void UpgradeOne()
    {
        Player.moveSpeed += .5f;
        GameManager.Instance.SwitchState<PlayingState>();
        upgradeMenu.SetActive(false);
        canvasMenu.SetActive(false);
    }
    public void UpgradeTwo()
    {
        ShootSpeed.cooldownHold -= .075f;
        GameManager.Instance.SwitchState<PlayingState>();
        upgradeMenu.SetActive(false);
        canvasMenu.SetActive(false);
    }
    public void UpgradeThree()
    {
        Player.maxTimer -= 0.05f;
        GameManager.Instance.SwitchState<PlayingState>();
        upgradeMenu.SetActive(false);
        canvasMenu.SetActive(false);
    }
}
