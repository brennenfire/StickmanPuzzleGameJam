using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform exit;
    [SerializeField] GameObject image;
    GameObject instantiatedObj;
    Player player;

    bool stopPlayer;

    private void Update()
    {
        if (stopPlayer == true)
        {
            player.animator.SetFloat("RunningSpeed", -1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Player>();
        if (player != null)
        {
            stopPlayer = true;
            instantiatedObj = Instantiate(image, transform.position, transform.rotation);
            StartCoroutine(WaitForTp());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = collision.GetComponent<Player>();
        if (player != null)
            stopPlayer = false;
    }

    IEnumerator WaitForTp()
    {
        Destroy(instantiatedObj, 2f);
        yield return new WaitForSeconds(1f);
        player.transform.position = exit.position;
    }
}
