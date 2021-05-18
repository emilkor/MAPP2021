using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

public class ButtonClamp : MonoBehaviour
{
    [SerializeField] private ScrollRect scroll;
    [SerializeField] private RectTransform gameObjectRect;
    [SerializeField] private RectTransform[] buttonsRect;
    

    private float lowestRect;
    private float highestRect;

    private Vector2 anchoredPos;
    private float xPos;


    // Start is called before the first frame update
    void Start()
    {
        lowestRect = Mathf.Infinity;
        highestRect = -Mathf.Infinity;

        foreach(RectTransform rect in buttonsRect)
        {
            if(rect.localPosition.x < lowestRect)
            {
                lowestRect = rect.localPosition.x;
            }
            if (rect.localPosition.x > highestRect)
            {
                highestRect = rect.localPosition.x;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        anchoredPos = gameObjectRect.anchoredPosition;
        xPos = anchoredPos.x;
        if(xPos < -highestRect || xPos > lowestRect)
        {
            scroll.StopMovement();
        }
        xPos = Mathf.Clamp(xPos, -highestRect, lowestRect);
        anchoredPos.x = xPos;
        gameObjectRect.anchoredPosition = anchoredPos;
    }
}
