using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : Collidable
{
    public int damage;
    public float pushForce;
    public bool hasAttackAni;
    private Animator animator;
    public bool canHit = true;

    private AudioSource audioSource;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Fighter") && coll.name == "Player" && canHit)
        {
            if(hasAttackAni)
            {
                animator.SetTrigger("attack");
            }
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            audioSource.Play();
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
