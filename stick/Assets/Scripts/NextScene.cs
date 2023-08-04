using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTest : MonoBehaviour
{
    [SerializeField] float changeTime;
    [SerializeField] bool autoChange;
    [SerializeField] string sceneName;
    [SerializeField] TMP_Text confirmationText;
    [SerializeField] Canvas confirmationCanvas;

    void Start()
    {
        confirmationCanvas.enabled = false;
        confirmationText.SetText(string.Empty);    
    }

    void Update()
    {
        if (changeTime != 0 && autoChange)
        {
            changeTime -= Time.deltaTime;
            if (changeTime <= 0)
            {
                ChangeScene();
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null && !autoChange) 
        {
            if(Input.GetKey(KeyCode.E)) 
            {
                confirmationCanvas.enabled = true;
                confirmationText.SetText("Are you sure  you want to go inside?");
            }
        }
    }

    public void Yes()
    {
        ChangeScene();
    }

    public void No()
    {
        confirmationCanvas.enabled = false;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
