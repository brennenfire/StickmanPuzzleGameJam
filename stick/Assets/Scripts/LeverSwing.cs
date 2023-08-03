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

    bool up;

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
                if(up == false)
                {
                    animator.SetTrigger("SwingDown");
                    up = !up;
                    onUp.Invoke();
                    StartCoroutine(WaitForLeverSwing());
                }
                else
                {
                    animator.SetTrigger("SwingUp");
                    up = !up;
                    onUp.Invoke();
                    StartCoroutine(WaitForLeverSwing());
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
}
