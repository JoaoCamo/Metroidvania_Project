using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float xSpeed;
    void LateUpdate()
    {
        if (!GameManager.instance.menuOpen && !GameManager.instance.player.attacking)
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            Vector3 movement = new Vector3(xInput * xSpeed * Time.deltaTime, 0, 0);
            if (movement.x > 0 || movement.x < 0)
            {
                transform.Translate(movement);
            }
        }
    }
}
