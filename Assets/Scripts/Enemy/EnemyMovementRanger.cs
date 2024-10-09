using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyMovementRanger : EnemyMovement
{
    [SerializeField] private GameObject ArrowPreFab;
    [SerializeField] private GameObject ArrowPos;
    private Transform ArrowDirection;
    [SerializeField] float ArrowSpeed;

    public float timer;

    private void Update()
    {

    }
    public override void fakeStart()
    {
        base.fakeStart();

    }

    public override void fakeUpdate()
    {
        base.fakeUpdate();
        float dist = Vector2.Distance(Player.position, transform.position);

        if (dist < 15)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                ShootArrow();
            }


            if (dist < 6)
            {
                timer += Time.deltaTime;
                if (timer > 1)
                {
                    timer = 0;
                    ShootArrow();
                }

                if (dist < 5)
                {

                    //Move away from player
                    moveSpeed = 4;
                    MoveAway();

                }

                if (dist > 5 && dist < 6)
                {
                    moveSpeed = 0;
                }

            }
            else if (dist > 5)
            {
                moveSpeed = 4;
            }
        }
    }

    public void MoveAway()
    {
        transform.position = transform.position - Player.position * Time.deltaTime;
    }

    private void ShootArrow()
    {

        Vector2 ArrowDirection = Player.transform.position - transform.position;
        
        GameObject Arrow = Instantiate(ArrowPreFab, transform.position, Quaternion.identity);
        Arrow.GetComponent<Rigidbody2D>().velocity = ArrowDirection.normalized * ArrowSpeed;
        Arrow.transform.up = ArrowDirection;
    }

}
