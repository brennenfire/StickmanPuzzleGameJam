using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] Canvas corners;

    Canvas canvas;
    public TMP_Text textComponent;
    public float textSpeed;
    string[] lines;

    public static Dialogue Instance { get; private set; }

    int index;

    void Start()
    {
        corners.enabled = false;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
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
        StartCoroutine(AppearCorners());
        LineCreator.Instance.enabled = false;
        canvas.enabled = true;
        textComponent.text = string.Empty;
        lines = dialogue.lines;
        index = 0;
        StartCoroutine(TypeLine());
        
    }

    IEnumerator AppearCorners()
    {
        corners.enabled = true;
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator DissappearCorners()
    {
        yield return new WaitForSeconds(0.1f);
        corners.enabled = false;
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
            StartCoroutine(DissappearCorners());
            LineCreator.Instance.enabled = true;
            canvas.enabled = false;
        }
    }
}
