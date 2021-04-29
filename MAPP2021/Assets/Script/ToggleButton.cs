using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public bool muteMusic;
    public bool muteSound;

    //private static bool universalEnable;
    private static bool musicEnable;
    private static bool soundEnable;

    private AudioManager am;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();

        if (muteMusic)
        {
            if (musicEnable)
            {
                ToggleTrue();
            }
            else
            {
                ToggleFalse();
            }
        }

        if (muteSound)
        {
            if (soundEnable)
            {
                ToggleTrue();
            }
            else
            {
                ToggleFalse();
            }
        }
        
        /*
        if (universalEnable)
        {
            ToggleTrue();
        }
        else
        {
            ToggleFalse();
        }*/
    }
    private void Update()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            if (muteMusic)
            {
                musicEnable = true;
                am.MuteMusic();
            }

            if (muteSound)
            {
                soundEnable = true;
                am.MuteSFX();
            }

            //universalEnable = true;
            //am.MuteAll();
        }
        else
        {
            if (muteMusic)
            {
                musicEnable = false;
                am.UnmuteMusic();
            }

            if (muteSound)
            {
                soundEnable = false;
                am.UnmuteSFX();
            }

            //universalEnable = false;
            //am.UnmuteAll();
        }
    }

    private void ToggleTrue()
    {
        gameObject.GetComponent<Toggle>().isOn = true;
    }

    private void ToggleFalse()
    {
        gameObject.GetComponent<Toggle>().isOn = false;
    }

    public bool getIsOn()
    {
        return gameObject.GetComponent<Toggle>().isOn;
    }
}

