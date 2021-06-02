using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAdapter : MonoBehaviour
{
    [SerializeField] private RectTransform[] menuItems;
    [SerializeField] private RectTransform canvas;


    private float screenhight;
    private float spaceBetween;
    
    // Start is called before the first frame update
    void Start()
    {
        screenhight = (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)) - Camera.main.ViewportToWorldPoint(new Vector3(0, 1f, 0))).y;
        Debug.Log(screenhight);
        spaceBetween = screenhight / menuItems.Length;
        for (int i = 0; i < menuItems.Length; i++)
        {
            menuItems[i].anchoredPosition = new Vector3(0, -(spaceBetween * (i + 1)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
