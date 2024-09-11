using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
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
}
