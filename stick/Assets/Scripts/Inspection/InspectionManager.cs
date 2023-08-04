using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InspectionManager : MonoBehaviour
{
    static Inspectable currentInspectable; 

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            currentInspectable = Inspectable.InspectablesInRange.FirstOrDefault();
        }
        if(Input.GetKeyDown(KeyCode.F) && currentInspectable != null) 
        {
            Debug.Log("inspected!");
            currentInspectable.CompleteInspection();
        }
        else
        {
            currentInspectable = null;
        }
    }
}
