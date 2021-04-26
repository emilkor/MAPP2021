using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

public class Spawner : MonoBehaviour
{
    private const int SPACE_BETWEEN_CATEGORIS = 20;
    private const int SPACE_WITHIN_CATEGORIS = 5;

    private enum PreviousStat
    {
        Box,
        Wall,
        Corridor,
        SideToSidePillar
    }
    
    [Header("Ods för olika mönster:")]
    [SerializeField] private float doBoxSpawn = .25f;
    [SerializeField] private float doWallSpawn = .5f;
    [SerializeField] private float doCorridorSpawn = .75f;
    [SerializeField] private float doSideToSidePillar = 1f;
    [Space(SPACE_BETWEEN_CATEGORIS)]

    [Header("Prefab som Spawnas:")]
    [SerializeField] private GameObject block;
    [Space(SPACE_BETWEEN_CATEGORIS)]

    [Header("Universala variabler:")]
    [SerializeField] private float raidiusOfPosibulPositions = 3f;
    [SerializeField] private int hightOfSpawnPosition = 10;
    [Space(SPACE_BETWEEN_CATEGORIS)]

    [Header("Box Spawn variabler:")]
    [SerializeField] private float minimumTimeBetweenBlocks = 2f;
    [SerializeField] private float maximumTimeBetweenBlocks = 4f;
    [Space(SPACE_WITHIN_CATEGORIS)]
    [SerializeField] private float minimumWidthOfBlock = 1f;
    [SerializeField] private float maximumWidthOfBlock = 4f;
    [Space(SPACE_WITHIN_CATEGORIS)]
    [SerializeField] private int minimumBoxesBeforSpawnChange = 15;
    [SerializeField] private int maximumBoxesBeforSpawnChange = 25;
    [Space(SPACE_BETWEEN_CATEGORIS)]

    [Header("Wall Spawn variabler:")]
    [SerializeField] private float minimumTimeBetweenWalls = 2f;
    [SerializeField] private float maximumTimeBetweenWalls = 4f;
    [Space(SPACE_WITHIN_CATEGORIS)]
    [SerializeField] private float minimumDistansBetweenWalls = 2f;
    [SerializeField] private float maximumDistansBetweenWalls = 4f;
    [Space(SPACE_WITHIN_CATEGORIS)]
    [SerializeField] private int minimumWallsBeforSpawnChange = 3;
    [SerializeField] private int maximumWallsBeforSpawnChange = 6;
    [Space(SPACE_BETWEEN_CATEGORIS)]

    [Header("Corridor Spawn variabler:")]
    [SerializeField] private float maximumCorridorCurv = 3f;
    [SerializeField] private float minimumCorridorCurv = 1f;
    [Space(SPACE_WITHIN_CATEGORIS)]
    [SerializeField] private float minimumDistansBetweenCorridorWalls = 7f;
    [SerializeField] private float maximumDistansBetweenCorridorWalls = 8f;
    [Space(SPACE_WITHIN_CATEGORIS)]
    [SerializeField] private int minimumCorridorsBeforSpawnChange = 20;
    [SerializeField] private int maximumCorridorsBeforSpawnChange = 30;
    [Space(SPACE_WITHIN_CATEGORIS)]
    [SerializeField] private float timeBetweenCorridorWalls = .5f;
    [Space(SPACE_WITHIN_CATEGORIS)]
    [SerializeField] private float chansOfCorridorChangeDirektion = .75f;
    [Space(SPACE_BETWEEN_CATEGORIS)]

    [Header("Side to side pillar fall:")]
    [SerializeField] private float pillarWidth = 2;
    [SerializeField] private float pillarHight = 5;
    [Space(SPACE_WITHIN_CATEGORIS)]
    [SerializeField] private float timeBetweenSideToSidePillarWalls = .5f;


    private float corridorHolePosition;
    private float corridorCurv;
    private int spawnAmount;
    private PreviousStat previousStat;

    

    private float modeVariabul;


    // Start is called before the first frame update
    void Start()
    {
        corridorCurv = Random.Range(-maximumCorridorCurv, maximumCorridorCurv);
        corridorHolePosition = Random.Range(-raidiusOfPosibulPositions, raidiusOfPosibulPositions);
        modeVariabul = Random.value;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private IEnumerator Spawn()
    {

        if (modeVariabul <= doBoxSpawn)
        {
            if (previousStat == PreviousStat.Box)
            {
                modeVariabul = Random.value;
            }
            else
            {
                spawnAmount = Random.Range(minimumBoxesBeforSpawnChange, maximumBoxesBeforSpawnChange);
                for (int i = 0; i < spawnAmount; i++)
                {
                    BoxSpawner();
                    yield return new WaitForSeconds(Random.Range(minimumTimeBetweenBlocks, maximumTimeBetweenBlocks));
                }
                modeVariabul = Random.value;
                previousStat = PreviousStat.Box;
            }

        }
        else if (modeVariabul <= doWallSpawn)
        {
            if (previousStat == PreviousStat.Wall)
            {
                modeVariabul = Random.value;
            }
            else
            {
                spawnAmount = Random.Range(minimumWallsBeforSpawnChange, maximumWallsBeforSpawnChange);
                block.transform.localScale = new Vector2(20, 1);
                for (int i = 0; i < spawnAmount; i++)
                {
                    WallSpawner();
                    yield return new WaitForSeconds(Random.Range(minimumTimeBetweenWalls, maximumTimeBetweenWalls));
                }
                modeVariabul = Random.value;
                previousStat = PreviousStat.Wall;
            }
        }
        else if (modeVariabul <= doCorridorSpawn)
        {
            if (previousStat == PreviousStat.Corridor)
            {
                modeVariabul = Random.value;
            }
            else
            {
                spawnAmount = Random.Range(minimumCorridorsBeforSpawnChange, maximumCorridorsBeforSpawnChange);
                block.transform.localScale = new Vector2(20, 1);
                for (int i = 0; i < spawnAmount; i++)
                {
                    CorridorSpawner();
                    yield return new WaitForSeconds(timeBetweenCorridorWalls);
                }
                modeVariabul = Random.value;
                previousStat = PreviousStat.Corridor;
            }
        }
        else /*if (modeVariabul <= doSideToSidePillar)*/
        {
            if (previousStat == PreviousStat.SideToSidePillar)
            {
                modeVariabul = Random.value;
            }
            else
            {
                block.transform.localScale = new Vector2(pillarWidth, pillarHight);
                int amountOfPillars = (int)Math.Ceiling(((raidiusOfPosibulPositions * 2)+1) / pillarWidth);
                int skipPillar = Random.Range(0, amountOfPillars);
                bool rightSideFirst = Random.value < .5f;
                //Debug.Break();
                for (int i = 0; i < amountOfPillars; i++)
                {
                    //Debug.Log(i);
                    sideToSidePillers(rightSideFirst, i, skipPillar);
                    yield return new WaitForSeconds(timeBetweenSideToSidePillarWalls);
                    //Debug.Log(i);
                }
                //Debug.Log("After Loop");
                modeVariabul = Random.value;
                previousStat = PreviousStat.SideToSidePillar;
            }
        }

        StartCoroutine(Spawn());


    }

    private void BoxSpawner()
    {

        block.transform.localScale = new Vector2(Random.Range(minimumWidthOfBlock, maximumWidthOfBlock), 1);
        Instantiate(block, new Vector2(Random.Range(-raidiusOfPosibulPositions, raidiusOfPosibulPositions), hightOfSpawnPosition), Quaternion.identity);
    }

    private void WallSpawner()
    {
        float distansBetweenWalls = Random.Range(minimumDistansBetweenWalls, maximumDistansBetweenWalls);
        float holePosition = Random.Range(-raidiusOfPosibulPositions, raidiusOfPosibulPositions);
        float leftWallPosition = holePosition - ((distansBetweenWalls + block.transform.localScale.x) / 2);
        float rightWallPosition = holePosition + ((distansBetweenWalls + block.transform.localScale.x) / 2);
        Instantiate(block, new Vector2(leftWallPosition, hightOfSpawnPosition), Quaternion.identity);
        Instantiate(block, new Vector2(rightWallPosition, hightOfSpawnPosition), Quaternion.identity);
    }

    private void CorridorSpawner()
    {
        float distansBetweenWalls = Random.Range(minimumDistansBetweenCorridorWalls, maximumDistansBetweenCorridorWalls);
        if(corridorHolePosition + maximumCorridorCurv > raidiusOfPosibulPositions)
        {
            corridorCurv = Random.Range(-maximumCorridorCurv, -minimumCorridorCurv);
        }
        else if (corridorHolePosition - maximumCorridorCurv < -raidiusOfPosibulPositions)
        {
            corridorCurv = Random.Range(minimumCorridorCurv, maximumCorridorCurv);
        }
        else if (corridorCurv > 0)
        {
            if (Random.value < chansOfCorridorChangeDirektion)
            {
                corridorCurv = Random.Range(minimumCorridorCurv, maximumCorridorCurv);
            }
            else corridorCurv = Random.Range(-maximumCorridorCurv, -minimumCorridorCurv);
        }
        else
        {
            if (Random.value < chansOfCorridorChangeDirektion)
            {
                corridorCurv = Random.Range(-maximumCorridorCurv, -minimumCorridorCurv); 
            }
            else corridorCurv = Random.Range(-minimumCorridorCurv, maximumCorridorCurv);
        }
        corridorHolePosition += corridorCurv;
        float leftWallPosition = corridorHolePosition - ((distansBetweenWalls + block.transform.localScale.x) / 2);
        float rightWallPosition = corridorHolePosition + ((distansBetweenWalls + block.transform.localScale.x) / 2);
        Instantiate(block, new Vector2(leftWallPosition, hightOfSpawnPosition), Quaternion.identity);
        Instantiate(block, new Vector2(rightWallPosition, hightOfSpawnPosition), Quaternion.identity);
    }

    private void sideToSidePillers(bool rightside, int pillarNumber, int skipPiller)
    {
        if (!(pillarNumber == skipPiller))
        {
            if (rightside)
            {
                Instantiate(block, new Vector2(raidiusOfPosibulPositions - (pillarNumber * pillarWidth), hightOfSpawnPosition), Quaternion.identity);
            }
            else
            {
                Instantiate(block, new Vector2(-raidiusOfPosibulPositions + (pillarNumber * pillarWidth), hightOfSpawnPosition), Quaternion.identity);
            }
        }
    }

    public int GetHightOfSpawnPosition()
    {
        return hightOfSpawnPosition;
    }
}
