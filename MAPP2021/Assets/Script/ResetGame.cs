using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("SecretSkin", 0);
        PlayerPrefs.SetFloat("HighScore", 0);
    }
}
