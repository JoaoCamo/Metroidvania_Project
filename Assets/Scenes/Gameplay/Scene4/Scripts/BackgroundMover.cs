using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private Transform player;
    private float boundX = 0f;

    void Start()
    {
        player = GameManager.instance.player.transform;   
    }

    void LateUpdate()
    {
        Vector3 background = Vector3.zero;

        float backgroundX = player.position.x - transform.position.x;
        if(backgroundX > boundX || backgroundX < -boundX)
        {
            if(transform.position.x < player.position.x)
            {
                background.x = backgroundX - boundX;
            } else {
                background.x = backgroundX + boundX;
            }
        }

        transform.position += new Vector3(background.x,0,0);
        
    }
}
