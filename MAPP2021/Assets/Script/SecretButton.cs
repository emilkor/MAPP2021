using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretButton : MonoBehaviour
{
    [SerializeField] private int unlockThreshold;


    private void Awake()
    {
        if (PlayerPrefs.GetString("SecretSkin") == "unlocked")
        {
            gameObject.GetComponent<Button>().interactable = true;

            GameObject lockImage = gameObject.transform.GetChild(1).gameObject;

            if (lockImage.name.Equals("Lock"))
            {
                lockImage.SetActive(false);
            }
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void SaveUnlocked()
    {
        if (PlayerPrefs.GetFloat("HighScore") >= unlockThreshold)
        {
            PlayerPrefs.SetString("SecretSkin", "unlocked");
            PlayerPrefs.Save();
        }
    }
}
