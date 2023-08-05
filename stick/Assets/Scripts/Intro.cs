using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitForEnd());        
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
