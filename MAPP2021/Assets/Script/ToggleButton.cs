using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    //private static int counter = 0;
    private static bool universalEnable;

    private AudioManager am;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();

        if (universalEnable)
        {
            ToggleTrue();
        }
        else
        {
            ToggleFalse();
        }
    }
    private void Update()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            universalEnable = true;
            am.MuteAll();
        }
        else
        {
            universalEnable = false;
            am.UnmuteAll();
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

    /*
    public void Counter()
    {
        counter++;
    }*/

    public bool getIsOn()
    {
        return gameObject.GetComponent<Toggle>().isOn;
    }
}

