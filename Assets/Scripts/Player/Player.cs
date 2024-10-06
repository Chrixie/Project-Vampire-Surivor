using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] Transform WeaponAround;
    public float moveSpeed { get; set; }
    public int maxHealth { get; set; }
    private int Health;
    [SerializeField] GameObject blood;

    [SerializeField] int currentXp;
    [SerializeField] int maxXp;
    [SerializeField] int currentLevel;

    public Rigidbody2D rb;
    private Vector2 moveDirection;

    [SerializeField] FloatingStatusBar healthBar;
    [SerializeField] FloatingStatusBar XpBar;

    [SerializeField] AnimationCurve myXpCurve;
    

    void Start()
    {
        maxHealth = 100;
        Health = maxHealth;
        currentXp = 0;
        currentLevel = 0;
        maxXp = 100;
        moveSpeed = 4;

    }

    /*public void Update()
    {
        ProcessInputs();
        Move();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowDirection = mousePos - (Vector2)transform.position;
        WeaponAround.up = bowDirection.normalized;
    }*/

    public void PlayerUpdate()
    {
        ProcessInputs();
        Move();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowDirection = mousePos - (Vector2)transform.position;
        WeaponAround.up = bowDirection.normalized;
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void TakeDamage(int damage)
    {
        healthBar.UpdateStatusBar(Health, maxHealth);
        Health -= damage;
        Instantiate(blood, transform.position, Quaternion.identity);
        if (Health < 0) Death();
    }
    void Death()
    {
        GameManager.Instance.SwitchState<DeathState>();
        Debug.Log("Player Died");
    }

    int IncreaseMaxXp()
    {
        return maxXp + (5 + currentLevel * 5);
    }

    public bool LvlUp(bool XPReached)
    {
        if (XPReached)
        {
            GameManager.Instance.SwitchState<UpgradeState>();
            return true;
        }
        return false;
    }

    public void XpGain()
    {
        currentXp +=50;
        XpBar.UpdateXpBar(currentXp, maxXp);

        Debug.Log("xp+");

        AnimationCurve c = myXpCurve;

        // maxXp = startXp + TotalMaxXp * curve.evaluate(currentLevel / maxLevel)

         if (currentXp >= maxXp)
         {
            currentLevel++;
            currentXp = 0;
            maxXp = IncreaseMaxXp();
            XpBar.UpdateXpBar(currentXp, maxXp);
            moveSpeed += 1;

            LvlUp(true);

             Debug.Log("lvl+");
         }

    }



}

   /*currentExperience;
     maxExperience;
     currentLevel;*/


  
      