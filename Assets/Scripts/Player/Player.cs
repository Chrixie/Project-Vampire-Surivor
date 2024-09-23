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
    [SerializeField] int currentExperience;
    [SerializeField] int maxExperience;
    [SerializeField] int currentLevel;
    private int Health;
    public Rigidbody2D rb;
    private Vector2 moveDirection;


    void Start()
    {
        Health = maxHealth;

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
        Health -= damage;
        if (Health < 0) Death();
    }
    void Death()
    {
            Debug.Log("Player Died");
    }
}
