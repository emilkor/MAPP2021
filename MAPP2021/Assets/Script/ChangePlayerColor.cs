using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerColor : MonoBehaviour
{
    private static Color newColor;



    [SerializeField] private Button[] buttons;
   // [SerializeField] private Text[] text;
    //[SerializeField] private Image[] image;

    private int highscore;


    private void Awake()
    {
        SetButtons();

        //VVV Ta bort sen /August
        PlayerPrefs.SetInt("HighScore", 10000);

        highscore = PlayerPrefs.GetInt("HighScore");

        if(highscore >= 0)
        {

            buttons[0].interactable = true;
            buttons[0].GetComponentInChildren<Image>().enabled = false;

            
        }

        if(highscore >= 2000)
        {
            buttons[1].interactable = true;
            buttons[1].GetComponentInChildren<Image>().enabled = false;

        }

        if(highscore >= 4000)
        {
            buttons[2].interactable = true;
            buttons[2].GetComponentInChildren<Image>().enabled = false;

        }

        if(highscore >= 6000)
        {
            buttons[3].interactable = true;
            buttons[3].GetComponentInChildren<Image>().enabled = false;

        }

        if(highscore >= 8000)
        {
            buttons[4].interactable = true;
            buttons[4].GetComponentInChildren<Image>().enabled = false;

        }

    }

    private void SetButtons()
    {

        foreach (Button button in buttons) {
            button.interactable = false;
        }
       
    }
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("HighScore"));
    }


    public static void White()
    {
        newColor = Color.white;
    }

    public static void Red()
    {
        newColor = Color.red;
    }

    public static void Blue()
    {
        newColor = Color.blue;

    }

    public static void Green()
    {
        newColor = Color.green;
    }

    public static void Pink()
    {
        newColor = new Color(1, 0, 1, 1);
    }

    public static void RandomColor()
    {
        newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
    }


    public static Color GetColor()
    {
        return newColor;
    }




}
