using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRainbow : MonoBehaviour
{
    [SerializeField] GameObject colorFilter;

    private void Update()
    {
        if (ToggleRainbow.IsRainbow())
        {
            colorFilter.SetActive(true);
        }

        else
        {
            colorFilter.SetActive(false);
        }
    }
}
