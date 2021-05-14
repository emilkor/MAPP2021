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

    private int unlocks;
    private float buttonValue;
    [SerializeField] private float unlockThreshold;
    [SerializeField] private float thresholdMultiplier;


    private void Awake()
    {
        SetButtons();

        //VVV Ta bort sen /August
        PlayerPrefs.SetInt("HighScore", 32000);

        highscore = PlayerPrefs.GetInt("HighScore");

        while(highscore >= unlockThreshold)
        {
            unlocks++;

            //Detta kan man ändra att bli mer linjärt etc /August
            buttonValue = unlockThreshold;
            unlockThreshold *= thresholdMultiplier;
        }

        //Alla knappar måste ha ett objekt som heter "Lock" som ligger på index 1 för att detta ska funka /August
        for(int i = 0; i < unlocks; i++)
        {
            buttons[i].interactable = true;
            GameObject lockImage = buttons[i].transform.GetChild(1).gameObject;

            if (lockImage.name.Equals("Lock"))
            {
                lockImage.SetActive(false);
            }
        }

        for(int i = unlocks; i < buttons.Length; i++)
        {
            Text buttonText = buttons[i].transform.GetChild(1).GetChild(0).GetComponent<Text>();

            //sätter texten på låsen /August
            buttonValue *= thresholdMultiplier;
            buttonText.text = buttonValue.ToString();
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

    public static void Cyan()
    {
        newColor = new Color(0, 1, 1, 1);
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
