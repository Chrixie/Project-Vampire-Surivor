using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanger : EnemyMovement
{
    public override void fakeStart()
    {
        base.fakeStart();

    }

    public override void fakeUpdate()
    {
        base.fakeUpdate();
        float dist = Vector2.Distance(Player.position, transform.position);


        if (dist <6)
        {

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
    public void MoveAway()
    {
        transform.position = transform.position - Player.position * Time.deltaTime;
    }

}
