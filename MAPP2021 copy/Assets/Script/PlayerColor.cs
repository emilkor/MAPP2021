using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class PlayerColor : MonoBehaviour
{
    [SerializeField] private Light2D pointLight;

    private Color playerColor;
    

    private void Awake()
    {
        SetPlayerColor(ChangePlayerColor.GetColor());
        
    }
    public void SetPlayerColor(Color color)
    {
        if (PlayerPrefs.GetString("randomColor").Equals("on"))
        {
            color = new Color(Random.value, Random.value, Random.value);
        }
        playerColor = color;
        

        gameObject.GetComponent<SpriteRenderer>().color = color;
        gameObject.GetComponent<TrailRenderer>().startColor = color;
        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(color);

        Color colorModified = color;
        colorModified.a = 0f;

        gameObject.GetComponent<TrailRenderer>().endColor = colorModified;

        pointLight.color = color;
    }

    public Color GetPlayerColor()
    {
        return playerColor;
    }

    public static void SetRandomColor(bool randomColor)
    {
        if (randomColor)
        {
            PlayerPrefs.SetString("randomColor", "on");
        }
        else
        {
            PlayerPrefs.SetString("randomColor", "off");
        }
    }
}
