using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject cameraFollowGO;

    public Animator animator;
    public Rigidbody2D rb;
    CameraFollowObject cameraFollowObject;

    public float horizontalMovement;
    public bool facingLeft = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        cameraFollowObject = cameraFollowGO.GetComponent<CameraFollowObject>();
    }

    void Update()
    {
        ReadHorizontalInput();
    }

    void FixedUpdate()
    {
        if(horizontalMovement != 0)
            TurnCheck();
        Movement();
    }

    void Movement()
    {
        if (horizontalMovement != 0)
        {
            animator.SetFloat("RunningSpeed", 1f);
            float newHorizontal = Mathf.Lerp(rb.velocity.x, horizontalMovement * speed, Time.fixedDeltaTime * 2f);
            rb.velocity = new Vector2(newHorizontal, rb.velocity.y);
        }
        else
        {
            animator.StopPlayback();
            animator.SetFloat("RunningSpeed", -1f);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    void ReadHorizontalInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
    }

    void TurnCheck()
    {
        if (horizontalMovement > 0 && facingLeft)
            Turn();
        else if (horizontalMovement < 0 && !facingLeft)
            Turn();
    }

    void Turn()
    {
        if (facingLeft)
        {
            Vector3 rotate = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotate);
            facingLeft = !facingLeft;

            cameraFollowObject.CallTurn();
        }
        else
        {
            Vector3 rotate = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotate);
            facingLeft = !facingLeft;

            cameraFollowObject.CallTurn();
        }
    }
}