using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class PlayerColor : MonoBehaviour
{
    [SerializeField] private Light2D pointLight;
    
    

    private void Awake()
    {
        SetPlayerColor(ChangePlayerColor.GetColor());
    }
    public void SetPlayerColor(Color color)
    {

        gameObject.GetComponent<SpriteRenderer>().color = color;
        gameObject.GetComponent<TrailRenderer>().startColor = color;
        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(color);

        Color colorModified = color;
        colorModified.a = 0f;

        gameObject.GetComponent<TrailRenderer>().endColor = colorModified;

        pointLight.color = color;
    }
}
