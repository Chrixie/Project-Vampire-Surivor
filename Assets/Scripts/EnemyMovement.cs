using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyMovement : Enemy
{
    [SerializeField] private float moveSpeed;
    private Vector2 movement;
    public Transform Player;
    protected float direction;
    public override void fakeStart()
    {
        base.fakeStart();
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    public void Update()
    {
       fakeUpdate();
    }
    public virtual void fakeUpdate()
    {
        //Wrong direction towards the player ////////////////////////////////////////////////////////////////////////////////////
        Vector3 direction = Player.position - transform.position;
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
        rb.velocity = ((direction * moveSpeed));

    }
}

