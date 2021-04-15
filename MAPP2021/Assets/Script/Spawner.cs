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

    [SerializeField] private GameObject block;

    [SerializeField] private float minimumTimeBetweenBlocks = 2f;
    [SerializeField] private float maximumTimeBetweenBlocks = 4f;

    [SerializeField] private float minimumWidthOfBlock = 1f;
    [SerializeField] private float maximumWidthOfBlock = 4f;

    [SerializeField] private float raidiusOfPosibulPositions = 3f;
    [SerializeField] private float hightOfSpawnPosition = 10f;

    [SerializeField] private float minimumTimeBetweenWalls = 2f;
    [SerializeField] private float maximumTimeBetweenWalls = 4f;

    [SerializeField] private float minimumDistansBetweenWalls = 2f;
    [SerializeField] private float maximumDistansBetweenWalls = 4f;

    [SerializeField] private float minimumTimeBetweenModeChange = 2f;
    [SerializeField] private float maximumTimeBetweenModeChange = 4f;

    private float modeVariabul;


    // Start is called before the first frame update
    void Start()
    {
        modeVariabul = Random.value;
        StartCoroutine(ModeChanger());
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ModeChanger()
    {
        yield return new WaitForSeconds(Random.Range(minimumTimeBetweenModeChange, maximumTimeBetweenModeChange));
        modeVariabul = Random.value;
        StartCoroutine(ModeChanger());
    }

    private void Spawn()
    {
        if (modeVariabul < .5)
        {
            StartCoroutine(BoxSpawner());
        }
        else
        {
            block.transform.localScale = new Vector2(20, 1);
            StartCoroutine(WallSpawner());
        }
        
    }

    private IEnumerator BoxSpawner()
    {
        yield return new WaitForSeconds(Random.Range(minimumTimeBetweenBlocks, maximumTimeBetweenBlocks));
        block.transform.localScale = new Vector2(Random.Range(minimumWidthOfBlock, maximumWidthOfBlock), 1);
        Instantiate(block, new Vector2(Random.Range(-raidiusOfPosibulPositions, raidiusOfPosibulPositions), hightOfSpawnPosition), Quaternion.identity);
        Spawn();
    }

    private IEnumerator WallSpawner()
    {
        yield return new WaitForSeconds(Random.Range(minimumTimeBetweenWalls, maximumTimeBetweenWalls));
        float distansBetweenWalls = Random.Range(minimumDistansBetweenWalls, maximumDistansBetweenWalls);
        float holePosition = Random.Range(-raidiusOfPosibulPositions, raidiusOfPosibulPositions);
        float leftWallPosition = holePosition - ((distansBetweenWalls + block.transform.localScale.x) / 2);
        float rightWallPosition = holePosition + ((distansBetweenWalls + block.transform.localScale.x) / 2);
        Instantiate(block, new Vector2(leftWallPosition, hightOfSpawnPosition), Quaternion.identity);
        Instantiate(block, new Vector2(rightWallPosition, hightOfSpawnPosition), Quaternion.identity);
        Spawn();
    }
}
