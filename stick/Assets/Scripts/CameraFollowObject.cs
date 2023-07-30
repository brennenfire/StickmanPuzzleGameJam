using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float cameraYoffset;

    Player player;
    bool facingLeft;
    float flipYrotationTime = .5f;

    void Awake()
    {
        player = playerTransform.gameObject.GetComponent<Player>();
        facingLeft = player.facingLeft;
    }

    void Update()
    {
        transform.position = playerTransform.position;
    }

    public void CallTurn()
    {
        LeanTween.rotateY(gameObject, DetermineEndRotation(), flipYrotationTime).setEaseInOutSine();
    }

    float DetermineEndRotation()
    {
        facingLeft = !facingLeft;

        if (facingLeft)
            return 180f;
        else
            return 0f;
    }
}
