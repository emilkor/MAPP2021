using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUI : MonoBehaviour
{
    private AudioManager am;

    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }

    public void PlayButtonPress()
    {
        am.Play("ButtonPress");
    }

    public void PlayStartButton()
    {
        am.Play("StartButton");
    }
}