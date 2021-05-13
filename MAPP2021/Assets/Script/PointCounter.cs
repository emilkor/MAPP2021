using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PointCounter : MonoBehaviour
{

    [SerializeField] private Text text;
    [SerializeField] private BlockSpeed blockSpeed;
    [SerializeField] private float pointSpeed;
    [SerializeField] private float pointsToTurnSolide;
    [Range(0f, 1f)]
    [SerializeField] private float chansOfTurnSolide;
    [SerializeField] private Spawner spawner;
    [SerializeField] private float timeWithSolideBackground;

    private float points;
    private bool haveActivatedMakeBackgroundSolid;
    private bool isMakeBackgroundSolid;



   // Update is called once per frame
    void FixedUpdate()
    {
        points = blockSpeed.GetPoint() * pointSpeed;
        text.text = string.Format("{0:0}", points);
        if (points % pointsToTurnSolide <= 2 && haveActivatedMakeBackgroundSolid)
        {
            haveActivatedMakeBackgroundSolid = false;
            MakeBackgroundSolid();
        }
        if (points > pointsToTurnSolide / 2)
        {
            haveActivatedMakeBackgroundSolid = true;
        }

        if (isMakeBackgroundSolid && GameObject.FindGameObjectsWithTag("Obstcle Block") == null)
        {
            StartCoroutine(SolideTimer())
        }
    }

    public String getPoints()
    {
        return text.text;
    }

    public int getPointsInt()
    {
        return (int) points;
    }

    private void MakeBackgroundSolid()
    {
        if(Random.value > chansOfTurnSolide)
        {
            spawner.enabled = false;
            BackgroundBlocks.MakeBackgroundSolid();
            isMakeBackgroundSolid = true;
        }
    }

    private IEnumerator SolideTimer()
    {
        yield return new WaitForSeconds(timeWithSolideBackground);
        BackgroundBlocks.MakeBackgroundUnsolid();
        spawner.enabled = true;
    }

}
