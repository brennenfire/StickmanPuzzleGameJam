using UnityEngine;

public class FlyTest : MonoBehaviour
{
    [SerializeField] float birdSpeed;

	Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(birdSpeed, rb.velocity.y);
    }
}
