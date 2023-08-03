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

    HashSet<Player> playerInRange = new HashSet<Player>();

    bool stopPlayer;
    [SerializeField] bool autoTP;

    void Start()
    {
        player = FindObjectOfType<Player>();    
    }

    void Update()
    {
        if (playerInRange.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.E) && autoTP == false)
            {
                player = FindObjectOfType<Player>();
                stopPlayer = true;
                instantiatedObj = Instantiate(image, transform.position, transform.rotation);
                StartCoroutine(WaitForTp());
            }
            else if (autoTP == true)
            {
                playerInRange.Clear();
                player = FindObjectOfType<Player>();
                stopPlayer = true;
                instantiatedObj = Instantiate(image, transform.position, transform.rotation);
                StartCoroutine(WaitForTp());
            }
        }

        
        if (stopPlayer == true)
        {
            player.animator.SetFloat("RunningSpeed", -1f);
            player.rb.velocity = new Vector2(0f, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange.Add(collision.GetComponent<Player>());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange.Remove(collision.GetComponent<Player>());
        }
    }

    IEnumerator WaitForTp()
    {
        Destroy(instantiatedObj, 1.4f);
        yield return new WaitForSeconds(.6f);
        stopPlayer = false;
        player.transform.position = exit.position;
    }
}
