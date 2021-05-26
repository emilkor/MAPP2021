using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("SecretSkin", "SecretSkin");
        PlayerPrefs.SetString("unlocked", "SecretSkin");
        PlayerPrefs.SetFloat("HighScore", 0);
    }
}
