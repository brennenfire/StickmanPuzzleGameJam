using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    Animator animator;
    Rigidbody2D rb;

    float horizontalMovement;
    bool facingLeft = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Flip();
        ReadHorizontalInput();
    }

    void FixedUpdate()
    {
        if (horizontalMovement != 0)
        {
            animator.SetFloat("RunningSpeed", 1f);
            float newHorizontal = Mathf.Lerp(rb.velocity.x, horizontalMovement * speed, Time.fixedDeltaTime * 2f);
            rb.velocity = new Vector2(newHorizontal, rb.velocity.y);
        }
        else
        {
            animator.SetFloat("RunningSpeed", -1f);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    void Flip()
    {
        if ((horizontalMovement > 0 && facingLeft) || (horizontalMovement < 0 && !facingLeft))
        {
            facingLeft = !facingLeft;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void ReadHorizontalInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
    }
}