using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReset : MonoBehaviour
{
    //[SerializeField] int counter;
    [SerializeField] float ink;
    [SerializeField] bool physics;

    new Collider2D collider;

    void Awake()
    {
        collider = GetComponent<Collider2D>();    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            collider.enabled = false;
            //LineCreator.Instance.lineCounter = counter;
            LineCreator.Instance.ink = ink;
            LineCreator.Instance.usePhysics = physics;
            //LineCreator.Instance.initialLineCounter = counter;
        }
    }
}
