using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//
        SceneManager.LoadScene("Level");

    }

    public void QuiteGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
         
}
