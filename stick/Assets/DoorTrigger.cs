using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationCurve curve;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Ball>() != null)
        {
            animator.SetTrigger("Open");
        }
    }
}
