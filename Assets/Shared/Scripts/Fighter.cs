using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float immuneTime = 0.25f;
    protected float lastImmune;

    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.showText(dmg.damageAmount.ToString(), 35, Color.red, transform.position, Vector3.up * 75, 0.5f);

            if(hitpoint <= 0)
            {
                hitpoint = 0;
                death();
            }
        }
    }

    protected virtual void death()
    {
        Debug.Log("log");
    }
}
