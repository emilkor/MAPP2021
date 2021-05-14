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

    [SerializeField] private float points;
    private bool haveNotActivatedMakeBackgroundSolid;
    private bool isMakeBackgroundSolid;



   // Update is called once per frame
    void FixedUpdate()
    {
        points = blockSpeed.GetPoint() * pointSpeed;
        text.text = string.Format("{0:0}", points);
        if (points % pointsToTurnSolide <= (pointsToTurnSolide / 2) - 1 && haveNotActivatedMakeBackgroundSolid)
        {

            haveNotActivatedMakeBackgroundSolid = false;
            MakeBackgroundSolid();
            Debug.Log("Set");
        }
        if (!haveNotActivatedMakeBackgroundSolid && points % pointsToTurnSolide > (pointsToTurnSolide / 2))
        {
            haveNotActivatedMakeBackgroundSolid = true;
            Debug.Log("Ready");
        }

        if (isMakeBackgroundSolid && GameObject.FindGameObjectsWithTag("Obstacle Block") == null)
        {
            isMakeBackgroundSolid = false;
            StartCoroutine(SolideTimer());
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
        if(Random.value < chansOfTurnSolide)
        {
            Spawner.StopSpawning();
            BackgroundBlocks.MakeBackgroundSolid();
            isMakeBackgroundSolid = true;
            Debug.Log("Go");
        }
    }

    private IEnumerator SolideTimer()
    {
        yield return new WaitForSeconds(timeWithSolideBackground);
        BackgroundBlocks.MakeBackgroundUnsolid();
        Spawner.StartSpawning();
    }

}
