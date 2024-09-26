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


        if (dist <= 5)
        {
            moveSpeed = 0;
            
            if (dist < 5)
            {
                //Move away from player
            }
            
        }
        else if (dist > 5)
        {
            moveSpeed = 4;
        }
    }

}
