using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

public class BlockSpawner : MonoBehaviour
{

    public GameObject block;
    public float minimumTimeBetweenBlocks = 2f;
    public float maximumTimeBetweenBlocks = 4f;
    public float raidiusOfPosibulBlockPositions = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(Random.Range(minimumTimeBetweenBlocks, minimumTimeBetweenBlocks));
        Instantiate(block, new Vector2(Random.Range(-raidiusOfPosibulBlockPositions, raidiusOfPosibulBlockPositions), 10));
        StartCoroutine(Spawner());

    }

    private void Instantiate(GameObject block, Vector2 vector2)
    {
        Instantiate(block, vector2);
    }
}
