using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFall : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Fighter") && coll.name == "Player")
        {
            coll.gameObject.transform.position = GameManager.instance.currentCheckpoint.position;
            if(GameManager.instance.player.hitpoint - 3 <= 0)
            {
                GameManager.instance.player.hitpoint = 0;
                GameManager.instance.menuOpen = true;
                GameManager.instance.mc.deathScreen.SetTrigger("show");
            } else {
                GameManager.instance.player.hitpoint -= 3;
            }
            GameManager.instance.player.HealthBarChange();
        } else if(coll.gameObject.CompareTag("Fighter")) {
            Destroy(coll.gameObject);
        }
    }
}
