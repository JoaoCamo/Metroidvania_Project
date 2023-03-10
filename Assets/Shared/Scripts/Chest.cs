using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collidable
{
    private bool collected = false;
    private int chestGold;
    private Animator animator;

    public int goldBottom, goldCeiling;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(!collected && coll.name == "Player")
        {
            collected = true;
            chestGold = Random.Range(goldBottom,goldCeiling);
            GameManager.instance.playerGold += chestGold;
            GameManager.instance.showText("+ " + chestGold.ToString(), 40, Color.yellow, transform.position, Vector3.up * 75, 1f);
            animator.SetTrigger("open");
        }
    }
}
