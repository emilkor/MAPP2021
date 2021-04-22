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
            showPoints();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    private void showPoints()
    {
        points.text = pointCounter.getPoints();
    }

    public void setAlive(bool alive)
    {
        isAlive = alive;
    }
}
