using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    public static ItemCheck Instance { get; private set; }

    void Awake()
    {
        Instance = this;    
    }

    public void DeactivateItem()
    {
        gameObject.SetActive(false);
    }
}
