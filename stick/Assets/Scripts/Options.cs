using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] TMP_Text showInk;
    int fakeInk;

    void Update()
    {
        fakeInk = (int)LineCreator.Instance.ink * 10;
        showInk.SetText("ink: " + fakeInk.ToString());
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
