using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioTest : MonoBehaviour
{
    [SerializeField] public AudioObject[] clipsToPlay;
    Collider2D collider;

    public static TriggerAudioTest Instance { get; private set; }    

    void Awake()
    {
        Instance = this;
        collider = GetComponent<Collider2D>();    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayClips();
            collider.enabled = false;
        }
    }

    private void PlayClips()
    {
        Vocals.Instance.Narration(clipsToPlay);
    }
}
