using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement
{
    private bool alive = true;
    public bool attacking = false;

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if(alive && !attacking)
        {
           UpdateMotor(new Vector3(x,0,0));
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("attack");
        }
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if(!alive)
        {
            return;
        }

        base.ReceiveDamage(dmg);
        GameManager.instance.HealthBarChange();
    }
}
