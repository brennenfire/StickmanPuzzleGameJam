using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InspectionManager : MonoBehaviour
{
    static Inspectable currentInspectable; 

    void Update()
    {
        if(Input.GetKey(KeyCode.E)) 
        {
            currentInspectable = Inspectable.InspectablesInRange.FirstOrDefault();
        }
        if(Input.GetKey(KeyCode.E) && currentInspectable != null) 
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
