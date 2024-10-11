using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.SocialPlatforms;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] Transform WeaponAround;
    [SerializeField] public float moveSpeed;
    public int maxHealth;
    [SerializeField] public int Health;
    [SerializeField] public int healthPerSecond;
    public float timer;
    public float maxTimer;
    [SerializeField] GameObject blood;

    [SerializeField] int currentXp;
    [SerializeField] int maxXp;
    [SerializeField] public int currentLevel;

    [SerializeField] Enemy enemy;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] Enemy enemyTank;
    [SerializeField] Enemy enemyRanger;
    [SerializeField] EnemyMovementRanger enemyMovementRanger;
    [SerializeField] EnemySpawner spawner;

    public Rigidbody2D rb;
    private Vector2 moveDirection;

    [SerializeField] FloatingStatusBar healthBar;
    [SerializeField] FloatingStatusBar XpBar;

    [SerializeField] AnimationCurve myXpCurve;

    public TMP_Text TimeAliveScore;
    public TMP_Text HighScore;


    private void Start()
    {
        timer = 0;
        maxTimer = 1;

        maxHealth = 100;
        healthPerSecond = 1;
        Health = maxHealth;

        moveSpeed = 4;

        currentXp = 0;
        currentLevel = 1;
        maxXp = 100;




        enemy.maxHealth = (int)(2f);
        enemyMovement.moveSpeed = (int)(3);

        enemyTank.maxHealth = (int)(4f);

        enemyRanger.maxHealth = (int)(1f);
        enemyMovementRanger.timer = (int)(2);

        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    public void PlayerUpdate()
    {
        ProcessInputs();
        Move();
        TimeAlive();
        HealthRegen();

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

    public void HealthRegen()
    {

        if (Health > maxHealth)
        {
            Health = maxHealth;
        }

        if (Health < maxHealth)
        {
            timer += Time.deltaTime;
            if (timer > maxTimer)
            {
                Health += (healthPerSecond);
                timer = 0;
                healthBar.UpdateStatusBar(Health, maxHealth);
            }

        }

        if (Health < 0)
        {
            Health = 0;
        }
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
        currentXp += 50;
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

            UpgradeEnemy();

            LvlUp(true);

            Debug.Log("lvl+");
        }

    }

    public void UpgradeEnemy()
    {

        if (currentLevel % 5 == 0)
        {
            enemy.maxHealth += (int)(enemy.maxHealth * 1.5);
            enemyMovement.moveSpeed += (int)(enemyMovement.moveSpeed * 0.05f);

            enemyTank.maxHealth += (int)(enemy.maxHealth * 3);

            enemyRanger.maxHealth += (int)(enemy.maxHealth * 1.5);
            enemyMovementRanger.timer += (int)(enemyMovementRanger.timer - 2);

            spawner.spawnTimer -= .2f;
        }
    }

    float TimeAliveCounter = 0f;
    public void TimeAlive()
    {
            TimeAliveCounter += Time.deltaTime;
            int TimeAliveInt = Mathf.FloorToInt(TimeAliveCounter);

            TimeAliveScore.text = "Time Alive " + TimeAliveInt.ToString() + " seconds";

            if (TimeAliveInt > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", TimeAliveInt);
            }
            HighScore.text = "Game Highscore: " + TimeAliveInt.ToString() + " seconds";
    }

}




