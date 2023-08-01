using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverSwing : MonoBehaviour
{
    HashSet<Player> playerInRange = new HashSet<Player>();
    Animator animator;

    [SerializeField] UnityEvent onDown;
    [SerializeField] UnityEvent onUp;

    bool down;

    void Start()
    {
        onUp.Invoke();
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
                    StartCoroutine(WaitForLeverSwing());
                }
                else
                {
                    animator.SetTrigger("SwingUp");
                    down = !down;
                    StartCoroutine(WaitForLeverSwing());
                }
                
            }
    }

    IEnumerator WaitForLeverSwing()
    {
        yield return new WaitForSeconds(.3f);

        if (down == false)
            onDown.Invoke();
        else
            onUp.Invoke();
    }
}
