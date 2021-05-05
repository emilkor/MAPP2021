using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject optionsMenu;


    private void Start()
    {
        optionsMenu.SetActive(false);
    }


    public void PlayGame ()
    {
        
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }

    public void QuiteGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
        
    }
         
}
