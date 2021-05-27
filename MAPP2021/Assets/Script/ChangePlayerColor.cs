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

    [SerializeField] private Button secretColor;
    private static Button staticSecretColor;


    private void Awake()
    {
        staticButtons = buttons;
        staticSecretColor = secretColor;
        SetButtons();

        //VVV Ta bort sen /August
        //PlayerPrefs.SetInt("HighScore", 0);
       

        highscore = PlayerPrefs.GetInt("HighScore");

        while (highscore >= unlockThreshold && unlocks < buttons.Length)
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

        buttonValue = unlockThreshold / thresholdMultiplier;
        print(buttonValue);

        for (int i = unlocks; i < buttons.Length; i++)
        {
            Text buttonText = buttons[i].transform.GetChild(1).GetChild(0).GetComponent<Text>();

            //s?tter texten p? l?sen /August
            buttonValue *= thresholdMultiplier;
            buttonValue = Mathf.Round(buttonValue);
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
        ActvateParticle();
        
    }

    public static void ChangeColor(Image image)
    {
        PlayerColor.SetRandomColor(false);
        newColor = image.color;
        SaveColor();
        ActvateParticle();
    }

    public static void White()
    {
        PlayerColor.SetRandomColor(false);
        newColor = Color.white;
        SaveColor();
        ActvateParticle();
    }

    //public static void Red()
    //{
    //    newColor = Color.red;
    //    SaveColor();
    //    ActvateParicule();
    //}

    //public static void DiffusedRed()
    //{
    //    newColor = new Color(1f, 0.5f, 0.5f, 1f);
    //    SaveColor();
    //    ActvateParicule();

    //}

    //public static void DiffusedGreen()
    //{
    //    newColor = new Color(0.5f, 1f, 0.5f, 1f);
    //    SaveColor();
    //    ActvateParicule();

    //}

    //public static void DiffusedBlue()
    //{
    //    newColor = new Color(0.5f, 0.5f, 1f, 1f);
    //    SaveColor();
    //    ActvateParicule();

    //}

    //public static void Blue()
    //{
    //    newColor = Color.blue;
    //    SaveColor();
    //    ActvateParicule();

    //}

    //public static void Green()
    //{
    //    newColor = Color.green;
    //    SaveColor();
    //    ActvateParicule();
    //}

    //public static void Pink()
    //{
    //    newColor = new Color(1, 0, 1, 1);
    //    SaveColor();
    //    ActvateParicule();
    //}

    //public static void Cyan()
    //{
    //    newColor = new Color(0, 1, 1, 1);
    //    SaveColor();
    //    ActvateParicule();
    //}

    //public static void Yellow()
    //{
    //    newColor = new Color(1, 1, 0, 1);
    //    SaveColor();
    //    ActvateParicule();
    //}

    //public static void Purple()
    //{
    //    newColor = new Color(0.5f, 0, 0.5f, 1);
    //    SaveColor();
    //    ActvateParicule();
    //}

    public static void RandomColor()
    {
        PlayerColor.SetRandomColor(true);
        ActvateParticle();
    }


    public static Color GetColor()
    {
        
        if (newColor.Equals(null))
        {
            White();
        }


        ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("PlayerColor"), out Color color);

        return color;
    }

    public static void SaveColor()
    {
        PlayerPrefs.SetString("PlayerColor", ColorUtility.ToHtmlStringRGBA(newColor));
        PlayerPrefs.SetFloat("ColorR", newColor.r);
        PlayerPrefs.SetFloat("ColorG", newColor.g);
        PlayerPrefs.SetFloat("ColorB", newColor.b);
        PlayerPrefs.SetFloat("ColorA", newColor.a);
        PlayerPrefs.Save();
    }

    public static void ActvateParticle()
    {
        Debug.Log(newColor);
        
        foreach (Button button in staticButtons)
        {
            
            if (button.gameObject.GetComponent<Image>().color == new Color(PlayerPrefs.GetFloat("ColorR"), PlayerPrefs.GetFloat("ColorG"), PlayerPrefs.GetFloat("ColorB"), PlayerPrefs.GetFloat("ColorA")) && !PlayerPrefs.GetString("randomColor").Equals("on"))
            {
                //Debug.Log("Why");
                button.gameObject.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                button.gameObject.GetComponent<ParticleSystem>().Stop();
            }
        }
        Debug.Log(PlayerPrefs.GetString("randomColor"));
        if (PlayerPrefs.GetString("randomColor").Equals("on"))
        {
            staticSecretColor.gameObject.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            staticSecretColor.gameObject.GetComponent<ParticleSystem>().Stop();

        }

    }


}
