using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverSwing : MonoBehaviour
{
    HashSet<Player> playerInRange = new HashSet<Player>();
    Animator animator;

    [SerializeField] UnityEvent onUp;
    [SerializeField] UnityEvent onDown;
    [SerializeField] bool timedLever;
    [SerializeField] float timer;

    bool up;
    
    void Start()
    {
        //if(!up)
        //{
            //onUp?.Invoke();
        //}
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
            
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (timedLever == false)
                {
                    if (up == false)
                    {
                        animator.SetTrigger("SwingDown");
                        up = !up;
                        StartCoroutine(WaitForLeverSwing());
                    }
                    else
                    {
                        animator.SetTrigger("SwingUp");
                        up = !up;
                        StartCoroutine(WaitForLeverSwing());
                    }
                }
                else
                {
                    animator.SetTrigger("SwingDown");
                    StartCoroutine(TimedLever());
                }
            }
        }
    }

    IEnumerator WaitForLeverSwing()
    {
        yield return new WaitForSeconds(.3f);

        if (up == false)
        {
            onUp.Invoke();
        }
        else
        {
            onDown.Invoke();
        }
    }

    IEnumerator TimedLever()
    {
        yield return new WaitForSeconds(.3f);
        onDown.Invoke();
        yield return new WaitForSeconds(timer);
        animator.SetTrigger("SwingUp");
        onUp.Invoke();

    }
}
