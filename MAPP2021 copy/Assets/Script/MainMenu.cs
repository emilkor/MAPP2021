using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject skinsMenu;
    [SerializeField] private Button playButton;

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
        playButton.enabled = false;
        transition.SetTrigger("Start"); //start triggern i animatorn

        yield return new WaitForSeconds(1f); //f� den  att v�nta antal sek


        SceneManager.LoadScene(levelIndex);
        //V�nta

        //Loada Scenen
    }

         
}
