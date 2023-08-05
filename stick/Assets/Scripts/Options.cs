using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] TMP_Text showInk;
    float fakeInk;

    void Update()
    {
        fakeInk = LineCreator.Instance.ink * 10;
        showInk.SetText("ink: " + fakeInk.ToString("f0"));
    }

    public void Quit()
    {
        Debug.Log("quit app");
        Application.Quit();
    }

    public void ClearLines()
    {
        LineCreator.Instance.ClearLines();
    }
 }
