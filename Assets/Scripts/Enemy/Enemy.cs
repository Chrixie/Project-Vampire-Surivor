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

    void Start()
    {
        fakeStart();
    }

    public virtual void fakeStart()
    {
        Health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0) Death();

        //if (Health <= 0) { Death(); }
    }

    void Death()
    {
        enemySpawner.RemoveSpawnedEnemy(gameObject);
        Destroy(gameObject);
    }

    //Damaging player (not implemented)
    private void OnTriggerEnter2D(Collider2D collision)
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
