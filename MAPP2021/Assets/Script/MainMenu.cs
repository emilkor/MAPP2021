using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject skinsMenu;

    public Animator transition; // referens till animator

    private void Start()
    {
        optionsMenu.SetActive(false);
        skinsMenu.SetActive(false);
     
    }


    public void PlayGame ()
    {

        //SceneManager.LoadScene(1);
        //Time.timeScale = 1;

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));


    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Spela aniamtion

        transition.SetTrigger("Start"); //start triggern i animatorn

        yield return new WaitForSeconds(1f); //få den  att vänta antal sek


        SceneManager.LoadScene(levelIndex);
        //Vänta

        //Loada Scenen
    }



    public void QuiteGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
        
    }
         
}
