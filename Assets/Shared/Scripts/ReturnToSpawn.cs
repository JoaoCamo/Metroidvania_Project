using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToSpawn : Collidable
{
    public Transform spawnPoint;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Fighter") && coll.name == "Player")
        {
            coll.gameObject.transform.position = spawnPoint.position;
            if(GameManager.instance.player.hitpoint - 3 <= 0)
            {
                GameManager.instance.player.hitpoint = 0;
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
