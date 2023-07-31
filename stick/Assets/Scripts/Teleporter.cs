using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform exit;
    [SerializeField] Image animationImage;
    [SerializeField] Animator animator;
    Player player;

    void Awake()
    {
        animationImage.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Player>();
        if (player != null)
        {
            animationImage.enabled = true;
            animator.SetBool("StartFadeInOut", true);
            StartCoroutine(WaitForTp());
        }
    }

    IEnumerator WaitForTp()
    {
        yield return new WaitForSeconds(1f);
        player.transform.position = exit.position;
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("StartFadeInOut", false);
        animationImage.enabled = false;
    }
}
