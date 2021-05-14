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
        Gradient gradient = new Gradient();
        gradient.colorKeys[0].color = color;
        gradient.colorKeys[1].color = color;

        gameObject.GetComponent<SpriteRenderer>().color = color;
        gameObject.GetComponent<TrailRenderer>().startColor = color;
        pointLight.color = color;
    }
}
