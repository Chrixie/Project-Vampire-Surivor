using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int Health;
    [SerializeField] public Rigidbody2D rb;
    [HideInInspector] public EnemySpawner enemySpawner;
    [SerializeField] FloatingStatusBar  healthBar;
    [SerializeField] public int GiveXp;
    public Player player;
    [SerializeField] GameObject XpBall;


    void Start()
    {
        fakeStart();
        healthBar = GetComponentInChildren<FloatingStatusBar>();
    }

    public virtual void fakeStart()
    {
        Health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.UpdateStatusBar(Health, maxHealth);
        if (Health <= 0) Death();
    }
        void Death()
    {
        player.XpGain();
        Instantiate(XpBall, transform.position, Quaternion.identity);
        enemySpawner.RemoveSpawnedEnemy(gameObject);
        Destroy(gameObject);
    }

    //Damaging player (not implemented)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player e = null;
            if (collision.TryGetComponent(out e))
            {
                e.TakeDamage(1);
            }
        }
    }
}

