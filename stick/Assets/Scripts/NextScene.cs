using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTest : MonoBehaviour
{
    [SerializeField] float changeTime;
    [SerializeField] bool autoChange;
    [SerializeField] string sceneName;

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
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
