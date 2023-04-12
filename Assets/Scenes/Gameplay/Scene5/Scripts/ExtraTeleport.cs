using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraTeleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            coll.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GameManager.instance.loadingScreen("Extra");
            GameManager.instance.mp.audioSource.Stop();
        }
    }
}
