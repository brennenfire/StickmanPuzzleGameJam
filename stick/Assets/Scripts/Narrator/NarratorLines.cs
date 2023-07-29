using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorLines : MonoBehaviour
{
    [SerializeField, TextArea] List<string> lines;

    void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player == null)
        {
            return;
        }
        Narrator.Instance.EnableCanvas();
        foreach(var line in lines) 
        {
            Narrator.Instance.SetText(line);
            StartCoroutine(WaitForNextLine());
            //Destroy(gameObject);
        }
    }

    IEnumerator WaitForNextLine()
    {
        yield return new WaitForSeconds(3f);
    }
}