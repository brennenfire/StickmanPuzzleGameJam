using System.Collections;
using UnityEngine;
using TMPro;
using System;
using System.Reflection;

public class Narrator : MonoBehaviour
{
    public static Narrator Instance { get; private set;}

    [SerializeField] public Canvas NarratorCanvas;
    [SerializeField] public TMP_Text narratorText;
    [SerializeField] public float textSpeed;

    void Awake()
    {
        narratorText.SetText(string.Empty);
        Instance = this;
        NarratorCanvas.enabled = false;    
    }

    /*
    public void SetText(string text)
    {
        StartCoroutine(TypeLine(text));
    }
    */

    public void EnableCanvas()
    {
        NarratorCanvas.enabled = true;
    }

    internal void DisableCanvas()
    {
        NarratorCanvas.enabled = false;
    }

    /*
    IEnumerator TypeLine(string text)
    {
        float messageTime = text.Length / 5;

        foreach (char c in text.ToCharArray())
        {
            narratorText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(messageTime + 1f);

        narratorText.SetText(string.Empty);
    }
    */
}
