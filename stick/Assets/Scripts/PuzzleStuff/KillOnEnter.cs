using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnEnter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            LineCreator.Instance.ClearLines();
            Player.Instance.Reset();
        }
    }
}
