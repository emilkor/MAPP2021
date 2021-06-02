using UnityEngine.Audio;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Sound
{

    public string name;

    public AudioClip clip;

    //public Animator musicAnimator;
    public AudioMixerGroup output;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    public bool mute;

    [HideInInspector]
    public AudioSource source;
}
