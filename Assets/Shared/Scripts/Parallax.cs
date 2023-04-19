using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float xSpeed;
    private Vector3 lastPos;
    private Transform player;
    private Vector3 velocity;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    
    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        if (Camera.main.transform.position.x != lastPos.x)
        {
            if (player.GetComponent<Rigidbody2D>().velocity.x != 0)
            {
                if(player.GetComponent<Rigidbody2D>().velocity.x > 0 || xInput < 0)
                {
                    return;
                } else if(player.GetComponent<Rigidbody2D>().velocity.x < 0 || xInput > 0) {
                    return;
                }
                velocity = new Vector3((player.GetComponent<Rigidbody2D>().velocity.x/150), 0, 0);
                transform.Translate(velocity);
            } else {
                Vector3 movement = new Vector3(xInput * xSpeed * Time.deltaTime, 0, 0);
                if (movement.x > 0 || movement.x < 0)
                {
                    transform.Translate(movement);
                }
            }
        }
        lastPos = Camera.main.transform.position;
    }
}