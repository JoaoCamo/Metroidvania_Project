using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Collidable
{
    public int[] SwordDamage = {1,3,5,7,10,15};
    public int swordLevel = 0;
    private float SwordKnockback = 5f;

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
                damageAmount = SwordDamage[swordLevel],
                origin = transform.position,
                pushForce = SwordKnockback
            };
            gameObject.transform.parent.GetComponent<Player>().audioSource.PlayOneShot(gameObject.transform.parent.GetComponent<Player>().playerSounds[0]);
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    public void upgradeSword()
    {
        if(swordLevel < (SwordDamage.Length-1))
        {
           swordLevel++;
        }
    }
}
