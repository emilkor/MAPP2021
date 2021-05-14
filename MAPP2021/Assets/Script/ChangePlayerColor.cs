using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerColor : MonoBehaviour
{
    private static Color newColor;
    [SerializeField] private Button buttonRed;


    private void Start()
    {
        buttonRed.enabled = false; 
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("Highscore") > 1000)
        {
            buttonRed.enabled = true;
        }
    }



    public void ChangeColorToRed()
    {
        newColor = Color.red;
    }

    public Color GetColor()
    {
        return newColor;
    }
}
