using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Object")]
public class AudioObject : ScriptableObject
{
    public AudioClip clip;
    [TextArea] public string subtitle;
}
