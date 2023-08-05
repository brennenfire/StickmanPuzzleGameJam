using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        float messageTime = lines[index].Length / 6;
        messageTime = Mathf.Clamp(messageTime, 3f, 15f);
        StartCoroutine(TypeLine(lines[index], messageTime));
        //StartCoroutine(WaitForNextLine(messageTime));
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            //narrator.SetText(lines[index]);
            TestDialogue();
        }
        else
        {
            narrator.DisableCanvas();
            Destroy(gameObject);
        }
    }

    /*
    IEnumerator WaitForNextLine(float time)
    {
        yield return new WaitForSeconds(time);
        narrator.narratorText.SetText(string.Empty);
        NextLine();
    }
    */

    IEnumerator TypeLine(string text, float time)
    {
        foreach (char c in text.ToCharArray())
        {
            narrator.narratorText.text += c;
            yield return new WaitForSeconds(narrator.textSpeed);
        }

        yield return new WaitForSeconds(1f);
        narrator.narratorText.SetText(string.Empty);
        NextLine();
    }
}