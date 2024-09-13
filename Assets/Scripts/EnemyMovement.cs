using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector2 movement;
    public Transform Player;
    //public GameObject Player2;
    private Rigidbody2D rb;
    private float direction;
    //public GameObject player;
    void Start()
    {
        //player = GameObject.FindFirstObjectByType<Player>().gameObject;
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        //transform.position += (player.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        Vector2 direction = Player.position - transform.position;
        //Vector2 direction = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}

