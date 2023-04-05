using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private Transform player;
    private float boundX = 0.1f;
    private float boundY = 0.15f;
    private float backgroundX;
    private float backgroundY;

    void Start()
    {
        player = GameManager.instance.player.transform;   
    }

    void LateUpdate()
    {
        Vector3 background = Vector3.zero;

        backgroundX = player.position.x - transform.position.x;
        if(backgroundX > boundX || backgroundX < -boundX)
        {
            if(transform.position.x < player.position.x)
            {
                background.x = backgroundX - boundX;
            } else {
                background.x = backgroundX + boundX;
            }
        }
        
        backgroundY = player.position.y - transform.position.y;
        if(backgroundY > boundY || backgroundY < -boundY)
        {
            if(transform.position.y < player.position.y)
            {
                background.y = backgroundY - boundY;
            } else {
                background.y = backgroundY + boundY;
            }
        }

        transform.position += new Vector3(background.x,background.y,0);
        
    }
}
