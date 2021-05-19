using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretButton : MonoBehaviour
{
    private static bool isUnlocked;


    private void Awake()
    {
        if (isUnlocked)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void SetUnlocked(bool toggle)
    {
        isUnlocked = toggle;
    }
}
