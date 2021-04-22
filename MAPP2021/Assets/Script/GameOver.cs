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

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void ShowPoints()
    {
        points.text = pointCounter.getPoints();
    }

    public void setAlive(bool alive)
    {
        isAlive = alive;
    }
}
