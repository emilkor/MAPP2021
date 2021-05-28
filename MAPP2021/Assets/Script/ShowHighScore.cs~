using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int highScore;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log(PlayerPrefs.GetInt("HighScore"));
        scoreText.text = highScore.ToString();
    }
}
