using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float pushVelocity;

    Rigidbody2D rigidBody;
    Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void PushBall()
    {
        rigidBody.velocity += new Vector2(pushVelocity, 0);
    }
    
    public void ResetBall()
    {
        transform.position = startingPosition;
        rigidBody.velocity = Vector3.zero;
    }
}
