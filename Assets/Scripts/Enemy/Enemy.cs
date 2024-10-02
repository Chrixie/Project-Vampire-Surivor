using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Enemy : MonoBehaviour
{
    [SerializeField] CircleCollider2D InnerCollider;
    [SerializeField] private int maxHealth;
    [SerializeField] private int Health;
    [SerializeField] public Rigidbody2D rb;
    [HideInInspector] public EnemySpawner enemySpawner;
    [SerializeField] FloatingStatusBar  healthBar;
    public Player player;
    [SerializeField] GameObject XpBall;
    [SerializeField] Animator animator;
    [SerializeField] GameObject BodyRemove;
    [SerializeField] GameObject blood;


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
        if (Health > 0) 
        {
            Health -= damage;
            healthBar.UpdateStatusBar(Health, maxHealth);
            if (Health <= 0)
            {
                BodyRemove.SetActive(false);
                InnerCollider.enabled = false;
                Death();
            }
        }
    }
    public virtual void Death()
    {
        Instantiate(XpBall, transform.position, Quaternion.identity);
        enemySpawner.RemoveSpawnedEnemy(gameObject);
        Instantiate(blood, transform.position, Quaternion.identity);
        animator.SetBool("isDead", true);
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

    public void deleteMe()
    {
        Destroy(gameObject);
    }
}

