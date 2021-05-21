using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleColor : MonoBehaviour
{

    private ParticleSystem.MainModule settings;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = gameObject.GetComponent<Image>().color;
        settings = GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
