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
    Vector3 startingPosition;
    float fallSpeedYDampingChangeThreshold;

    public static Player Instance { get; private set; } 

    void Start()
    {
        Instance = this;
        startingPosition = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        cameraFollowObject = cameraFollowGO.GetComponent<CameraFollowObject>();
        fallSpeedYDampingChangeThreshold = CameraManager.Instance.fallSpeedYDampingChangeThreshold;
    }

    void Update()
    {
        if (rb.velocity.y < fallSpeedYDampingChangeThreshold && !CameraManager.Instance.IsLerpingYDamping && !CameraManager.Instance.LerpedFromPlayerFalling)
            CameraManager.Instance.LerpYdamping(true);
        if(rb.velocity.y >= 0f && !CameraManager.Instance.IsLerpingYDamping && !CameraManager.Instance.LerpedFromPlayerFalling)
        {
            CameraManager.Instance.LerpedFromPlayerFalling = false;
            CameraManager.Instance.LerpYdamping(false);
        }

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PositionReset>() != null)
        {
            startingPosition = collision.GetComponent<PositionReset>().transform.position;
        }
    }

    [ContextMenu("try reset pos")]
    public void Reset()
    {
        transform.position = startingPosition; 
    }
}
