using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScorePopUp : MonoBehaviour
{
    public Text text;
    private PointCounter pointCounter;

    public int popThreshold;

    [SerializeField] private Vector3 startSize;
    public Vector3 targetSize;

    [SerializeField] private float duration;
    private float timeRemaining;

    private void Start()
    {
        
    }

    void Awake()
    {
        gameObject.transform.localScale = startSize;
        pointCounter = FindObjectOfType<PointCounter>();
    }

    void Update()
    {
        int score = pointCounter.getPointsInt();

        if(score == popThreshold)
        {
            text.text = pointCounter.getPoints();
            PopUp();
            //VVV �ndra h�r f�r att �ndra popup intervallerna
            popThreshold *= 2;
        }

        if(timeRemaining > 0f)
        {
            gameObject.transform.localScale += (targetSize - gameObject.transform.localScale) * 0.1f;
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            //VVV m�jligtvis kn�ppt /August
            if(gameObject.transform.localScale != new Vector3(0, 0, 0))
            {
                gameObject.transform.localScale += (startSize - gameObject.transform.localScale) * 0.1f;

            }
        }

    }

    public void PopUp()
    {
        timeRemaining = duration;
    }
}
