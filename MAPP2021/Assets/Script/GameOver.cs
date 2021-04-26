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
  
    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == false)
        {
            gameOverScreen.SetActive(true);
            highScoreText.enabled = false;
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
    }

    private void ShowPoints()
    {
        points.text = pointCounter.getPoints();

        string s = pointCounter.getPoints();
        int possibleHighScore = int.Parse(s);

        if(possibleHighScore > PlayerPrefs.GetInt("HighScore"))
        {
            highScoreText.enabled = true;
            PlayerPrefs.SetInt("HighScore", possibleHighScore);
            PlayerPrefs.Save();
        }
    }

    public void setAlive(bool alive)
    {
        isAlive = alive;
    }
}
