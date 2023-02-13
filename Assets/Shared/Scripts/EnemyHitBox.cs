using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : Collidable
{
    public int damage;
    public float pushForce;
    public bool hasAtackAni;
    private Animator animator;
    public bool canHit = true;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Fighter") && coll.name == "Player" && canHit)
        {
            if(hasAtackAni)
            {
                animator.SetTrigger("attack");
            }
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
