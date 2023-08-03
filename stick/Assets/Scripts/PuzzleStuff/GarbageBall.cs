using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Player>() != null)
        {
            Player.Instance.Reset();
        }
        else if(collision.collider.GetComponent<GarbageBall>() != null)
        {
            return;
        }
        else if(collision.collider.GetComponent<IgnoreObject>() != null)
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
