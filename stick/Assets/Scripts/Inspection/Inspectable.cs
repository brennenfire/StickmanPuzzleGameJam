using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Inspectable : MonoBehaviour
{
    public static event Action<bool> InspectablesInRangeChanged;
    //public static event Action<Inspectable, string> AnyInspectionComplete;

    static HashSet<Inspectable> inspectablesInRange = new HashSet<Inspectable>();

    [SerializeField] UnityEvent OnInspectionCompleted;

    [SerializeField, TextArea] string completedInspectionText;
    [SerializeField] TMP_Text completedInspectionTextBox;
    [SerializeField] Item item;
    [SerializeField] bool isPickup = false;

    public static IReadOnlyCollection<Inspectable> InspectablesInRange => inspectablesInRange;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("he here....");
            inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (inspectablesInRange.Remove(this))
            {
                InspectablesInRangeChanged?.Invoke(inspectablesInRange.Any());
            }
        }
    }

    public void CompleteInspection()
    {
        if (isPickup)
        {
            Inventory.Instance.AddItem(item);
            gameObject.SetActive(false);
            return;
        }
        //Debug.Log("inspection wokr!!!");
        inspectablesInRange.Remove(this);
        InspectablesInRangeChanged?.Invoke(inspectablesInRange.Any());
        OnInspectionCompleted?.Invoke();
        //AnyInspectionComplete?.Invoke(this, completedInspectionText);
        completedInspectionTextBox?.SetText(completedInspectionText);
        if (completedInspectionTextBox != null)
            completedInspectionTextBox.enabled = true;
        float messageTime = completedInspectionText.Length / 5;
        messageTime = Mathf.Clamp(messageTime, 3f, 15f);
        StartCoroutine(FadeCompletedText(messageTime));
    }

    IEnumerator FadeCompletedText(float messageTime)
    {
        completedInspectionTextBox.alpha = 1f;
        while (completedInspectionTextBox.alpha > 0f)
        {
            yield return null;
            completedInspectionTextBox.alpha -= Time.deltaTime / messageTime;
        }

        completedInspectionTextBox.enabled = false;
    }

    /*
    void RestoreInspectionText()
    {
        inspectablesInRange.Remove(this);
        InspectablesInRangeChanged?.Invoke(inspectablesInRange.Any());
        OnInspectionCompleted?.Invoke();
    }
    */
}
