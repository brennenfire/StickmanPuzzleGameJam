using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReset : MonoBehaviour
{
    [SerializeField] int counter;
    [SerializeField] bool physics;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            LineCreator.Instance.lineCounter = counter;
            LineCreator.Instance.usePhysics = physics;
        }
    }
}
