using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerColor : MonoBehaviour
{
    private static Color newColor;
    [SerializeField] private Button buttonOne;
    [SerializeField] private Button buttonTwo;
    private int highscore;


    /* 
     private void Awake()
      {
          DontDestroyOnLoad(gameObject);
      }

      */

    private void Awake()
    {
        highscore = PlayerPrefs.GetInt("HighScore");

        if(highscore >= 1000)
        {
            buttonOne.enabled = true;
        }

        if(highscore >= 3000)
        {
            buttonTwo.enabled = true; 
        }
    }
    private void Start()
    {
        buttonOne.enabled = false;
        buttonTwo.enabled = false;
        Debug.Log(PlayerPrefs.GetInt("HighScore"));
    }


    public static void ChangeColorToBlue()
    {
        newColor = Color.blue;

    }

    public static void ChangeColorToRed()
    {
        newColor = Color.red;
    }

    public static Color GetColor()
    {
        return newColor;
    }




}
