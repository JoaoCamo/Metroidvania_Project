using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement
{
    private bool alive = true;

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if(alive == true)
        {
            UpdateMotor(new Vector3(x,0,0));
        }
    }
}
