using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private bool canDash = true;
    private float xInput;
    private Rigidbody2D rb;
    private float dashCooldown = 2.5f;
    private float currentTime;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }
    
    private void Update()
    {
        if (Time.time - currentTime > dashCooldown)
        {
            canDash = true;
            if (Input.GetKeyDown(GameManager.instance.dash) && canDash && gameObject.GetComponent<Player>().hasSpeedBoots)
            {
                dash();
                currentTime = Time.time;
            }
        }
    }
    
    private void dash()
    {
        if (xInput != 0)
        {
            rb.AddForce(transform.right * xInput * 2.5f, ForceMode2D.Impulse);
            canDash = false;
            if (xInput > 0)
            {
                GameManager.instance.showParticle(new Vector3(transform.position.x,transform.position.y - 0.35f, transform.position.z), 5, 5f);
            } else {
                GameManager.instance.showParticle(new Vector3(transform.position.x,transform.position.y - 0.35f, transform.position.z), 6, 5f);  
            }
        }
    }
}
