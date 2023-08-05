using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnEnter : MonoBehaviour
{
    [SerializeField] GameObject image;
    GameObject instantiatedObj;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            LineCreator.Instance.ClearLines();
            Player.Instance.Reset();
            instantiatedObj = Instantiate(image, transform.position, transform.rotation);
            StartCoroutine(WaitForTp());
        }
    }

    IEnumerator WaitForTp()
    {
        Destroy(instantiatedObj, 1.4f);
        yield return new WaitForSeconds(.6f);
    }
}
