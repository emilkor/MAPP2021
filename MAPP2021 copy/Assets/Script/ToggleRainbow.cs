using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleRainbow : MonoBehaviour
{
    [SerializeField] private bool rainbowMode;
    

    private static bool rainbow;

    private void Awake()
    {
       if (rainbow)
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
        if(gameObject.GetComponent<Toggle>().isOn)
        {
            rainbow = true;
        }

        else
        {
            rainbow = false;
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

    public static bool IsRainbow()
    {
        return rainbow;
    }
}
