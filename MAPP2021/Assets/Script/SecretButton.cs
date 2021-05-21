using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretButton : MonoBehaviour
{
    [SerializeField] private int unlockThreshold;


    private void Awake()
    {
        if (PlayerPrefs.GetInt("SecretSkin") > 0 && PlayerPrefs.GetFloat("HighScore") >= unlockThreshold)
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

    public static void SaveUnlocked(int value)
    {
        PlayerPrefs.SetInt("SecretSkin", value);
        PlayerPrefs.Save();
    }
}