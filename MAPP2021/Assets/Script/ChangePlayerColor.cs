using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerColor : MonoBehaviour
{
    private static Color newColor;



    [SerializeField] private Button[] buttons;
    private static Button[] staticButtons;

    private int highscore;

    private int unlocks = 1;
    private float buttonValue;
    [SerializeField] private float unlockThreshold;
    [SerializeField] private float thresholdMultiplier;


    private void Awake()
    {
        staticButtons = buttons;
        SetButtons();

        //VVV Ta bort sen /August
         //PlayerPrefs.SetInt("HighScore", 1000000);

        highscore = PlayerPrefs.GetInt("HighScore");

        while (highscore >= unlockThreshold)
        {
            unlocks++;

            //Detta kan man ?ndra att bli mer linj?rt etc /August
            unlockThreshold *= thresholdMultiplier;
        }

        //Alla knappar m?ste ha ett objekt som heter "Lock" som ligger p? index 1 f?r att detta ska funka /August
        for (int i = 0; i < unlocks; i++)
        {
            buttons[i].interactable = true;
            GameObject lockImage = buttons[i].transform.GetChild(1).gameObject;

            if (lockImage.name.Equals("Lock"))
            {
                lockImage.SetActive(false);
            }
        }

        buttonValue = unlockThreshold / 2;
        print(buttonValue);

        for (int i = unlocks; i < buttons.Length; i++)
        {
            Text buttonText = buttons[i].transform.GetChild(1).GetChild(0).GetComponent<Text>();

            //s?tter texten p? l?sen /August
            buttonValue *= thresholdMultiplier;
            buttonText.text = buttonValue.ToString();

            if (buttonValue >= 10000)
            {
                buttonText.fontSize -= 2;
            }

            if (buttonValue >= 100000)
            {
                buttonText.fontSize -= 2;
            }
        }
    }

    private void SetButtons()
    {

        foreach (Button button in buttons)
        {
            button.interactable = false;
        }

    }
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("HighScore"));
        print(PlayerPrefs.GetString("PlayerColor"));
        ActvateParicule();
    }


    public static void White()
    {
        newColor = Color.white;
        SaveColor();
        ActvateParicule();
    }

    public static void Red()
    {
        newColor = Color.red;
        SaveColor();
        ActvateParicule();
    }

    public static void DiffusedRed()
    {
        newColor = new Color(1f, 0.5f, 0.5f, 1f);
        SaveColor();
        ActvateParicule();

    }

    public static void DiffusedGreen()
    {
        newColor = new Color(0.5f, 1f, 0.5f, 1f);
        SaveColor();
        ActvateParicule();

    }

    public static void DiffusedBlue()
    {
        newColor = new Color(0.5f, 0.5f, 1f, 1f);
        SaveColor();
        ActvateParicule();

    }

    public static void Blue()
    {
        newColor = Color.blue;
        SaveColor();
        ActvateParicule();

    }

    public static void Green()
    {
        newColor = Color.green;
        SaveColor();
        ActvateParicule();
    }

    public static void Pink()
    {
        newColor = new Color(1, 0, 1, 1);
        SaveColor();
        ActvateParicule();
    }

    public static void Cyan()
    {
        newColor = new Color(0, 1, 1, 1);
        SaveColor();
        ActvateParicule();
    }

    public static void Yellow()
    {
        newColor = new Color(1, 1, 0, 1);
        SaveColor();
        ActvateParicule();
    }

    public static void Purple()
    {
        newColor = new Color(0.5f, 0, 0.5f, 1);
        SaveColor();
        ActvateParicule();
    }

    public static void RandomColor()
    {
        newColor = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        print(newColor);
        SaveColor();
        ActvateParicule();
    }


    public static Color GetColor()
    {
        
        if (newColor.Equals(null))
        {
            White();
        }
        
        Color color;

        ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("PlayerColor"), out color);

        return color;
    }

    public static void SaveColor()
    {
        PlayerPrefs.SetString("PlayerColor", ColorUtility.ToHtmlStringRGBA(newColor));
        PlayerPrefs.Save();
    }

    private static void ActvateParicule()
    {
        Debug.Log(staticButtons.Length);

        foreach (Button button in staticButtons)
        {
            
            if (button.gameObject.GetComponent<Image>().color == GetColor())
            {
                //Debug.Log("Why");
                button.gameObject.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                button.gameObject.GetComponent<ParticleSystem>().Stop();
            }
          
        }
    }


}
