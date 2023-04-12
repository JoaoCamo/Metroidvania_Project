using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Collidable
{
    private int damage = 10;
    private float pushForce = 5f;
    public bool active;
    public int type;
    public float speed;

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
        }

        if (!coll.gameObject.CompareTag("Bullet") && coll.gameObject.layer != 7)
        {
            Hide();
        }
    }

    private void FixedUpdate()
    {
        transform.Translate( 0f,speed * Time.deltaTime,0f);
    }

    public void Show()
    {
        active = true;
        gameObject.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        gameObject.SetActive(active);
    }
}
