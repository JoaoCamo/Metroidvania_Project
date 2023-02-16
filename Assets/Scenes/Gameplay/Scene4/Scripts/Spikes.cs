using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Collidable
{
    private int damage = 3;
    private float pushForce = 0;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Fighter") && coll.name == "Player")
        {
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            coll.SendMessage("ReceiveDamage", dmg);
        } else if(coll.gameObject.CompareTag("Fighter")) {
            Destroy(coll.gameObject);
        }
    }
}
