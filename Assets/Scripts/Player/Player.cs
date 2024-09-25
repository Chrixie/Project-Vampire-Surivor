using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] Transform WeaponAround;
    [SerializeField] float moveSpeed;
    [SerializeField] int maxHealth;
    private int Health;

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
        Health = maxHealth;
        currentXp = 0;
        currentLevel = 0;
        maxXp = 0;
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
        if (Health < 0) Death();
    }
    void Death()
    {
        GameManager.Instance.SwitchState<PauseState>();
        Debug.Log("Player Died");
    }

    int IncreaseMaxXp()
    {
        return maxXp + (5 + currentLevel * 5);
    }

    public void XpGain()
    {
        currentXp +=100;
        XpBar.UpdateXpBar(currentXp, maxXp);

        Debug.Log("xp+");

        AnimationCurve c = myXpCurve;

        // maxXp = startXp + TotalMaxXp * curve.evaluate(currentLevel / maxLevel)
        float result = Mathf.Lerp(7, -7, 0.5f);
        
        if (currentXp >= maxXp)
        {
            currentLevel++;
            currentXp = 0;
            maxXp = IncreaseMaxXp();
            XpBar.UpdateXpBar(currentXp, maxXp);
            GameManager.Instance.SwitchState<UpgradeState>();

            Debug.Log("lvl+");
        }

        
        
    }

   /*currentExperience;
     maxExperience;
     currentLevel;*/


}     
      