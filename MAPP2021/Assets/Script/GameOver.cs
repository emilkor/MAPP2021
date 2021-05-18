using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text points;
    [SerializeField] private PointCounter pointCounter;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject counter;
    [SerializeField] private GameObject powerUpButton;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Animator animator;
  
    private bool isAlive;

    
    void Start()
    {
        gameOverScreen.SetActive(false);
        highScoreText.enabled = false;
        isAlive = true;
        
        Debug.Log(PlayerPrefs.GetInt("HighScore", 0));
       // PlayerPrefs.SetInt("HighScore", 0);
    }

   

    // Update is called once per frame
    void Update()
    {
        if (isAlive == false)
        {
            gameOverScreen.SetActive(true);
            ShowPoints();
            ClearScreen();
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    private void ClearScreen()
    {
        pauseButton.SetActive(false);
        counter.SetActive(false);
        powerUpButton.SetActive(false);

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    private void ShowPoints()
    {
        points.text = pointCounter.getPoints();


        int possibleHighScore = pointCounter.getPointsInt();

        if(possibleHighScore > PlayerPrefs.GetInt("HighScore"))
        {
            highScoreText.enabled = true;
            PlayerPrefs.SetInt("HighScore", possibleHighScore);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt("HighScore", 0));
            return;
           
        }

        else if (possibleHighScore < PlayerPrefs.GetInt("HighScore"))
        {
            highScoreText.text = "Score";
            highScoreText.fontSize = 150;
            highScoreText.enabled = true;
            animator.enabled = false;
        }

        
    }

    public void setAlive(bool alive)
    {
        isAlive = alive;
    }
}
