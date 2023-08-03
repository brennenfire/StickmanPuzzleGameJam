using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Player>() != null)
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
