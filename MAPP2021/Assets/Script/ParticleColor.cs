using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleColor : MonoBehaviour
{
    private ParticleSystem particle;
    private ParticleSystem.MainModule settings;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = gameObject.GetComponent<Image>().color;
        particle = GetComponent<ParticleSystem>();
        settings = particle.main;
        settings.startColor = new ParticleSystem.MinMaxGradient(color);

        //var colorOverLifetime = particle.colorOverLifetime;

        //Gradient gradient = new Gradient();
        //gradient.SetKeys(
        //    new GradientColorKey[] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 0.5f), new GradientColorKey(color, 1.0f) },
        //    new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.5f), new GradientAlphaKey(0.0f, 1.0f) }
        //);

        //colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
    }

    // Update is called once per frame
    
}
