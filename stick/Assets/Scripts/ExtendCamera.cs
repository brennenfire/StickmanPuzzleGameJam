using UnityEngine;

public class ExtendCamera : MonoBehaviour
{
    [SerializeField] GameObject cameraTarget;
    [SerializeField] bool isExit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isExit == false)
            if (collision.CompareTag("Player"))
                cameraTarget.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isExit == true)
            if (collision.CompareTag("Player"))
                cameraTarget.SetActive(false);
    }
}
