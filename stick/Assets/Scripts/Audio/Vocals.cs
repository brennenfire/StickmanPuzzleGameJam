using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    int index = 0;
    float delay = 0f;
    AudioSource source;
    AudioObject[] localClips;
    public static Vocals Instance { get; private set; }

    void Awake()
    {
        Instance = this; 
    }

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        delay = 0f;
    }


    public void Narration(AudioObject[] clips)
    {
        localClips = clips;
        index = 0;
        Say(localClips[index]);
    }
    
    public void Say(AudioObject clip)
    {
        delay = clip.clip.length;
        if (source.isPlaying)
        {
            source.Stop();
        }
        source.PlayOneShot(clip.clip);

        UI.Instance.SetSubtitle(clip.subtitle, delay);
        index++;
        if(index >= localClips.Length) 
        {
            return;
        }

        StartCoroutine(WaitForNextLine());
    }

    IEnumerator WaitForNextLine()
    {
        yield return new WaitForSeconds(delay + 1f);
        Say(localClips[index]);
    }
}
