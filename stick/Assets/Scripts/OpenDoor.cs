using UnityEngine.Events;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] UnityEvent onPressE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player == null)
            return;

        onPressE.Invoke();
    }

}
