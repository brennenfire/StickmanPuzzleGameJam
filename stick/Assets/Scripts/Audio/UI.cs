using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text subtitleText = default;
    [SerializeField] Canvas canvas;

    public static UI Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        ClearSubtitle();
    }

    public void SetSubtitle(string text, float delay)
    {
        canvas.enabled = true;
        subtitleText.SetText(text);
        StartCoroutine(ClearAfterSeconds(delay));
    }

    public void ClearSubtitle()
    {
        subtitleText.SetText("");
        canvas.enabled = false;
    }

    IEnumerator ClearAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearSubtitle();
    }
}
