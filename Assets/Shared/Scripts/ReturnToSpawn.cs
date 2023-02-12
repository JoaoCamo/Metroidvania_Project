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
            GameManager.instance.player.hitpoint -= 3;
        }
    }
}
