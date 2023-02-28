using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Movement
{
    public float trigger;
    public float chase;
    private bool chasing;
    private bool colliding;
    private Transform playerTransform;
    private Vector3 startingPosition;
    protected bool alive = true;
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] Hits = new Collider2D[10];

    protected int enemyGoldDrop;

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if(alive)
        {
            if(Vector3.Distance(playerTransform.transform.position, startingPosition) < chase)
            {
                if(Vector3.Distance(playerTransform.transform.position, startingPosition) < trigger)
                {
                    chasing = true;
                }

                if(chasing)
                {
                    if(!colliding)
                    {
                        UpdateMotor((playerTransform.transform.position - transform.position).normalized);
                    }
                } else {
                    UpdateMotor(startingPosition - transform.position);
                }
            } else {
                UpdateMotor(startingPosition - transform.position);
                chasing = false;
            }

            colliding = false;
            BoxCollider.OverlapCollider(filter,Hits);
            for(int i = 0; i < Hits.Length; i++)
            {
                if(Hits[i] == null)
                {
                    continue;
                }

                if(Hits[i].tag == "Fighter" && Hits[i].name == "Player")
                {
                    colliding = true;
                }

                Hits[i] = null;
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
    }

    protected override void death()
    {
        animator.SetTrigger("dead");
        alive = false;
        gameObject.GetComponent<EnemyHitBox>().canHit = false;
        enemyGoldDrop = Random.Range(2,8);
        GameManager.instance.playerGold += enemyGoldDrop;
        GameManager.instance.showText("+ " + enemyGoldDrop.ToString(), 40, Color.yellow, transform.position, Vector3.up * 75, 1f);
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
