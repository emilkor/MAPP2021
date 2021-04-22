using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ColourChange : MonoBehaviour
{

    [SerializeField] private Image image;
    [SerializeField] private float speed = .1f; 
    private float upcomingColor;

    // Start is called before the first frame update
    void Start()
    {
        upcomingColor = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        upcomingColor = Mathf.Lerp(0f, 1f, Time.time * speed);
        image.color = Color.HSVToRGB(upcomingColor, 1f, 1f) - new Color(0, 0, 0, 0.5f);
        
        if (upcomingColor >= 1f)
        {
            upcomingColor = 0f;
        }
       

    }
}
