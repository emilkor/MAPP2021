using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerColor : MonoBehaviour
{
    private static Color newColor;



    [SerializeField] private Button[] buttons;
    [SerializeField] private Text[] text;

    private int highscore;


    private void Awake()
    {
        SetButtons();

        PlayerPrefs.SetInt("HighScore", 0);

        highscore = PlayerPrefs.GetInt("HighScore");

        if(highscore >= 0)
        {
            buttons[0].interactable = true;
            text[0].enabled = false;
        }

        if(highscore >= 2000)
        {
            buttons[1].interactable = true;
            text[1].enabled = false;
           
        }

        if(highscore >= 4000)
        {
            buttons[2].interactable = true;
            text[2].enabled = false;
           
        }

        if(highscore >= 6000)
        {
            buttons[3].interactable = true;
            text[3].enabled = false;
            
        }

        if(highscore >= 8000)
        {
            buttons[4].interactable = true;
            text[4].enabled = false;
         
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


    public static Color GetColor()
    {
        return newColor;
    }




}
