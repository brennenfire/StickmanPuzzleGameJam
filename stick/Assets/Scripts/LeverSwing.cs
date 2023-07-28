using System.Collections.Generic;
using UnityEngine;

public class LeverSwing : MonoBehaviour
{
    HashSet<Player> playerInRange = new HashSet<Player>();
    Animator animator;

    bool down;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange.Add(collision.GetComponent<Player>());
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange.Remove(collision.GetComponent<Player>());
    }

    void Update()
    {
        if (playerInRange.Count > 0)
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(down == false)
                {
                    animator.SetTrigger("SwingDown");
                    down = !down;
                }
                else
                {
                    animator.SetTrigger("SwingUp");
                    down = !down;
                }
                
            }
    }
}
