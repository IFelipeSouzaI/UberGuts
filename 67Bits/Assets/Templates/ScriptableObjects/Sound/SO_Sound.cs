using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSfx", menuName = "SFX")]
public class SO_Sound : ScriptableObject
{
    public string name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume = 1f;
    [Range(0.1f, 3f)]
    public float pitch = 1f;
    public bool loop = false;
    [HideInInspector]
    public AudioSource source;
}
