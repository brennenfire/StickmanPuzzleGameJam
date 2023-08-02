using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TMP_Text textComponent;
    public float textSpeed;
    string[] lines;

    public static Dialogue Instance { get; private set; }

    int index;

    void Start()
    {
        gameObject.SetActive(false);
        Instance = this;
        textComponent.text = string.Empty;    
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }    
    }

    public void StartDialogue(DialogueObject dialogue)
    {
        gameObject.SetActive(true);
        lines = dialogue.lines;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1) 
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            LineCreator.Instance.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
