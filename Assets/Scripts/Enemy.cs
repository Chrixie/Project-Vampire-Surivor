using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private int Health;
    public Rigidbody2D rb;

    void Start()
    {
        Health = maxHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0) Death();
    }

    void Death()
    {
        Destroy(gameObject);
    }

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
