using System.Collections;
using UnityEngine;
using TMPro;

public class Narrator : MonoBehaviour
{
    public static Narrator Instance { get; private set;}

    [SerializeField] public Canvas NarratorCanvas;
    [SerializeField] TMP_Text narratorText;

    void Awake()
    {
        Instance = this;
        NarratorCanvas.enabled = false;    
    }

    public void SetText(string text)
    {
        narratorText.SetText(text);
    }

    public void EnableCanvas()
    {
        NarratorCanvas.enabled = true;
    }
}
