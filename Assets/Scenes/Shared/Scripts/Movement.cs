using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Fighter
{
    private Vector3 originalSize;
    protected BoxCollider2D BoxCollider;
    protected Vector3 movement;
    protected RaycastHit2D hit;
    protected Animator animator;
    public float xSpeed = 1f;

    protected virtual void Start()
    {
        originalSize = transform.localScale;
        BoxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    protected virtual void UpdateMotor(Vector3 Input)
    {
        movement = new Vector3(Input.x * xSpeed,0,0);

            if(movement.x > 0)
            {
                transform.localScale = originalSize;
                animator.SetBool("moving", true);
            } else if(movement.x < 0) {
                transform.localScale = new Vector3(originalSize.x * -1, originalSize.y, originalSize.z);
                animator.SetBool("moving", true);
            } else if( movement.x == 0) {
                animator.SetBool("moving", false);
            }

        movement += pushDirection;

        pushDirection = Vector3.Lerp(pushDirection,Vector3.zero,pushRecoverySpeed);

        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(movement.x, 0), Mathf.Abs(movement.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            transform.Translate(movement.x * Time.deltaTime, 0, 0);
        }
    }
}
