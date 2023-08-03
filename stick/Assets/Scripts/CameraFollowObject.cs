using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

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
        transform.position = player.transform.position + new Vector3(0, 5f, 0);
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
