using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{

    [SerializeField] private Text text;
    [SerializeField] private BlockSpeed blockSpeed;
    [SerializeField] private float pointSpeed;



   // Update is called once per frame
   void FixedUpdate()
    {
        text.text = string.Format("{0:0}", blockSpeed.GetPoint()*pointSpeed);
    }

    public String getPoints()
    {
        return text.text;
    }
}
