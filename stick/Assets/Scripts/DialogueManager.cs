using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;

    public TMP_Text dialogueText;
    Canvas canvas;

    public static DialogueManager Instance { get; private set; }

    void Start()
    {
        Instance = this;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        canvas.enabled = true;
        sentences.Clear();

        foreach(var sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.SetText("");
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        canvas.enabled = false;
        LineCreator.Instance.enabled = true;
    }
}
