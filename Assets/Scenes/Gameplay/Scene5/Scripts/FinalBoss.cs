using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : Enemy
{
    public Animator dialogAnimator;
    public Animator ending;
    private bool canDie = false;
    private bool dialogMenuOpen = false;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if(dialogMenuOpen)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {

            } else if(Input.GetKeyDown(KeyCode.Backspace)){

            }
        }
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            if(hitpoint <= 0)
            {
                hitpoint = 0;
                showDialog();
            } else if(hitpoint <= 0 && canDie) {
                death();
            }
        }
    }

    private void showDialog()
    {
        dialogAnimator.SetTrigger("show");
        dialogMenuOpen = true;
        alive = false;
    }

    protected override void death()
    {
        animator.SetTrigger("dead");
        alive = false;
        gameObject.GetComponent<EnemyHitBox>().canHit = false;
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
