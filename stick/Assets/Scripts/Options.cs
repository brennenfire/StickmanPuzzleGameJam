using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("quit app");
        Application.Quit();
    }
 }
