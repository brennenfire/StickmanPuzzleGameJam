using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [Header("Jumping Variables")]
    [SerializeField] float jumpPower;
    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpMultiplier;

    Rigidbody2D rb;
    Vector2 vecGravity;
    Animator anim;

    bool isJumping;
    float jumpCounter;
    float jumpBufferCounter;
    float coyoteTimeCounter;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            anim.SetTrigger("Jump");

        ReadJumpInput();
        DoJump();
        StopJump();
        CoyoteTime();
        JumpBuffer();

        if (rb.velocity.y < 0)
            rb.velocity -= fallMultiplier * Time.deltaTime * vecGravity;
    }

    private void JumpBuffer()
    {
        if (Input.GetButtonDown("Jump"))
            jumpBufferCounter = 0.2f;
        else
            jumpBufferCounter -= Time.deltaTime;
    }

    private void CoyoteTime()
    {
        if (isGrounded())
            coyoteTimeCounter = .3f;
        else
            coyoteTimeCounter -= Time.deltaTime;
    }

    private void StopJump()
    {
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpCounter = 0;

            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);

            coyoteTimeCounter = 0;
        }
    }

    private void DoJump()
    {
        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime)
                isJumping = false;

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if (t > 0.5f)
                currentJumpM = jumpMultiplier * (1 - t);

            rb.velocity += vecGravity * currentJumpM * Time.deltaTime;
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.14f, groundLayer);
    }

    void ReadJumpInput()
    {
        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;

            jumpBufferCounter = 0;
        }
    }
}
