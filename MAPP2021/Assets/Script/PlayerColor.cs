using System.Collections;
using System.Collections.Generic;
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
        playerColor = color;

        gameObject.GetComponent<SpriteRenderer>().color = color;
        gameObject.GetComponent<TrailRenderer>().startColor = color;
        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(color);

        Color colorModified = color;
        colorModified.a = 0f;

        gameObject.GetComponent<TrailRenderer>().endColor = colorModified;

        pointLight.color = color;

        SaveColor(color);
    }

    public Color GetPlayerColor()
    {
        return playerColor;
    }

    public void SaveColor(Color color)
    {
        PlayerPrefs.SetString("PlayerColor", ColorUtility.ToHtmlStringRGBA(color));
        PlayerPrefs.Save();
    }
}
