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
    [SerializeField] bool down = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (down == false)
        {
            animator.SetTrigger("SwingDown");
            down = !down;
            onDown.Invoke();
        }
        else
        {
            animator.SetTrigger("SwingUp");
            down = !down;
            onUp.Invoke();
        }
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
                    onDown.Invoke();
                    //StartCoroutine(WaitForLeverSwing());
                }
                else
                {
                    animator.SetTrigger("SwingUp");
                    down = !down;
                    onUp.Invoke();
                    //StartCoroutine(WaitForLeverSwing());
                }
                
            }
    }

    IEnumerator WaitForLeverSwing()
    {
        yield return new WaitForSeconds(.3f);

        if (down == false)
        {
            onDown.Invoke();
        }
        else
        {
            onUp.Invoke();
        }
    }
}
