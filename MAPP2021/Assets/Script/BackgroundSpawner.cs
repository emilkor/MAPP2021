using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private BackgroundBlocks blocksScript;
    


    private float spaceBetween;
    private float cameraWidth;
    private int colomOfBlocks;
    private GameObject lastBlock;
    private float spawnHight;
    private int rowsOfBlocks;

    private bool left;


    // Start is called before the first frame update
    void Start()
    {
        spaceBetween = blocksScript.GetMaxSize() * 2;
        cameraWidth = (float) Camera.main.orthographicSize * Camera.main.aspect * 2;
        rowsOfBlocks = Mathf.CeilToInt(Camera.main.orthographicSize / spaceBetween * 4);
        colomOfBlocks = Mathf.CeilToInt(cameraWidth / spaceBetween);
        spawnHight = Camera.main.orthographicSize + Mathf.Sqrt(Mathf.Pow(blocksScript.GetMaxSize(), 2) / 2);
        FillScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastBlock != null && lastBlock.transform.position.y <= spawnHight - (spaceBetween / 2))
        {
            SpawnRow();
        }
    }

    void SpawnRow()
    {

        if (left)
        {
            for (int i = 0; i <= colomOfBlocks; i++)
            {
                lastBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * i), spawnHight), Quaternion.identity);
            }
        }
        else
        {
            for (int i = 0; i <= (colomOfBlocks); i++)
            {
                lastBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * i) + (spaceBetween /2), spawnHight), Quaternion.identity);
            }

        }
        left = !left;
    }
    void FillScreen()
    {
        for (int i = 0; i <= rowsOfBlocks; i++)
        {
            if (left)
            {
                for (int j = 0; j <= colomOfBlocks; j++)
                {
                    lastBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * j), spawnHight - (spaceBetween / 2 * (rowsOfBlocks - i))), Quaternion.identity);
                }
            }
            else
            {
                for (int j = 0; j <= colomOfBlocks; j++)
                {
                    lastBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * j) + (spaceBetween / 2), spawnHight - (spaceBetween / 2 * (rowsOfBlocks - i))), Quaternion.identity);
                }
            }
            left = !left;
        }
        
        
    }
}
