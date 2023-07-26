using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal;
    [SerializeField] float acceleration = 1f;
    [SerializeField] float deceleration = 1f;
    string horizontalAxis;
    new Rigidbody2D rigidbody2D;

    [SerializeField] float speed;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        horizontalAxis = "Horizontal";
    }

    void Update()
    {
        ReadHorizontalInput();
        if (horizontal != 0)
            MoveHorizontal();

        void ReadHorizontalInput()
        {
            horizontal = Input.GetAxis(horizontalAxis) * speed;
        }

        void MoveHorizontal()
        {
            float smoothnessMultiplier = horizontal == 0 ? deceleration : acceleration;
            float newHorizontal = Mathf.Lerp(rigidbody2D.velocity.x, horizontal * speed, Time.deltaTime * smoothnessMultiplier);
            rigidbody2D.velocity = new Vector2(newHorizontal, rigidbody2D.velocity.y);
        }
    }
}