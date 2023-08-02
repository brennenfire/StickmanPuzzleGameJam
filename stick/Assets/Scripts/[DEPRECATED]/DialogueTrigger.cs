using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    HashSet<Player> playerInRange = new HashSet<Player>();
    public DialogueObject dialogue;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange.Add(collision.GetComponent<Player>());
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange.Remove(collision.GetComponent<Player>());
    }

    void Update()
    {
        if (playerInRange.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
        }
    }

    [ContextMenu("test dialogue")]
    public void TriggerDialogue()
    {
        LineCreator.Instance.enabled = false;
        Dialogue.Instance.StartDialogue(dialogue);
    }
    
}
