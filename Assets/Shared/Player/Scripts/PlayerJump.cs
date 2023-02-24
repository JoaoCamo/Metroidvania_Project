using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private float jumpVelocity = 4f;
    private bool isGrounded = true;
    private Rigidbody2D rb;
    private Animator animator;
    public bool hasDoubleJump = false;
    public bool doubleJumped = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        jump();
    }

    //Pulo do player
    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Z) && isGrounded && !gameObject.GetComponent<Player>().attacking && !GameManager.instance.menuOpen)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            animator.SetTrigger("jump");
            gameObject.GetComponent<Player>().audioSource.PlayOneShot(gameObject.GetComponent<Player>().playerSounds[1]);
        } else if(Input.GetKeyDown(KeyCode.Z) && hasDoubleJump && !doubleJumped && !isGrounded && !gameObject.GetComponent<Player>().attacking)
        {
            doubleJumped = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            animator.SetTrigger("jump");
            gameObject.GetComponent<Player>().audioSource.PlayOneShot(gameObject.GetComponent<Player>().playerSounds[1]);
        }
    }

    //Checar se está no chão
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            doubleJumped = false;
            isGrounded = true;
            animator.SetTrigger("hitGround");
        }
    }

    //Checar se saiu do chão
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.ResetTrigger("hitGround");
            animator.ResetTrigger("jump");
        }
    }
}
