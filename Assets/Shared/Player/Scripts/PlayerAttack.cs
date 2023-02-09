using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Collidable
{
    public int SwordDamage;
    private float SwordKnockback = 10f;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Fighter"))
        {
            if(coll.name == "Player")
            {
                return;
            }
            Damage dmg = new Damage
            {
                damageAmount = SwordDamage,
                origin = transform.position,
                pushForce = SwordKnockback
            };
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
