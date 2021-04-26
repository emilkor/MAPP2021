using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

   [SerializeField] private GameObject pauseMenuUI;
   [SerializeField] private static bool GameIsPaused = false;
   [SerializeField] private GameObject pauseButton;
   [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject powerUpButton;
   

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        powerUpButton.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        optionsMenu.SetActive(false);
        powerUpButton.SetActive(false);
       
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Options()
    {
        pauseMenuUI.SetActive(false);
        optionsMenu.SetActive(true);
        
    }

    public void BackToPauseScreen()
    {
        optionsMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
