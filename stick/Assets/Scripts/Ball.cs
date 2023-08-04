using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float pushVelocityX;
    [SerializeField] float pushVelocityY;

    Rigidbody2D rigidBody;
    Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void PushBall()
    {
        rigidBody.velocity += new Vector2(pushVelocityX, pushVelocityY);
    }
    
    public void ResetBall()
    {
        transform.position = startingPosition;
        rigidBody.velocity = Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            ResetBall();
        }
    }
}
