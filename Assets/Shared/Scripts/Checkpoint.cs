using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool reached = false;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(!reached && coll.name == "Player")
        {
            GameManager.instance.currentCheckpoint = this.transform;
            reached = true;
        }
    }
}
