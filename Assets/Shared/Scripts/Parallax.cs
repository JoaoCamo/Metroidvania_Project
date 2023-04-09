using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float xSpeed;
    private Vector3 lastPos;

    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        if (Camera.main.transform.position.x != lastPos.x)
        {
            Vector3 movement = new Vector3(xInput * xSpeed * Time.deltaTime, 0, 0);
            if (movement.x > 0 || movement.x < 0)
            {
                transform.Translate(movement);
            }
        }
        lastPos = Camera.main.transform.position;
    }
}