using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject skinsMenu;
 


    private void Start()
    {
        optionsMenu.SetActive(false);
        skinsMenu.SetActive(false);
     
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
