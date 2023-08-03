using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorLines : MonoBehaviour
{
    [SerializeField, TextArea] string[] lines;

    int index = 0;

    Narrator narrator;
    new Collider2D collider;
    
    void Start()
    {
        narrator = Narrator.Instance;
        collider = GetComponent<Collider2D>();
    }

    [ContextMenu("test dialogue")]

    void OnTriggerEnter2D(Collider2D collision)
    {
        collider.enabled = false;
        TestDialogue();
    }

    void TestDialogue()
    {
        narrator.EnableCanvas();
        narrator.SetText(lines[index]);
        StartCoroutine(WaitForNextLine());
    }

    IEnumerator WaitForNextLine()
    {
        yield return new WaitForSeconds(3f);
        if (index < lines.Length - 1)
        {
            index++;
            narrator.SetText(lines[index]);
            TestDialogue();
        }
        else
        {
            narrator.DisableCanvas();
            Destroy(gameObject);
        }
    }
}