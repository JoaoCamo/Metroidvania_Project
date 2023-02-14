using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement
{
    private bool alive = true;
    public bool attacking = false;
    public bool tookDamage = false;

    public bool hasSpeedBoots = false;
    public int armorLevel = 0;

    private float hitCooldown = 0.75f;
    private float lastSwing;

    private void FixedUpdate()
    {
        float xInput = Input.GetAxisRaw("Horizontal");

        if(alive && !attacking && !GameManager.instance.menuOpen)
        {
           UpdateMotor(new Vector3(xInput,0,0));
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && !tookDamage)
        {
            if(Time.time - lastSwing > hitCooldown)
            {
                lastSwing = Time.time;
                animator.SetTrigger("attack");
            }
        }
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if(!alive)
        {
            return;
        }
        
        animator.SetTrigger("hit");
        base.ReceiveDamage(dmg);
        HealthBarChange();
    }

    protected override void death()
    {
        alive = false;
        animator.SetTrigger("dead");
        GameManager.instance.menuOpen = true;
        GameManager.instance.mc.deathScreen.SetTrigger("show");
        GameManager.instance.playerGold -= 20;
    }

    public void HealthBarChange()
    {
        float ratio = (float)hitpoint / (float)maxHitpoint;
        GameManager.instance.mc.healthBar.localScale = new Vector3(ratio, 1, 1);
    }

    public void upgradeArmor()
    {
        armorLevel++;
        maxHitpoint += 10;
        hitpoint = maxHitpoint;
    }

    public void loadHealth()
    {
        maxHitpoint += (armorLevel*10);
        hitpoint = maxHitpoint;
    }

    public void respawn()
    {
        animator.SetTrigger("respawn");
        hitpoint = maxHitpoint;
        HealthBarChange();
        alive = true;
    }
}
