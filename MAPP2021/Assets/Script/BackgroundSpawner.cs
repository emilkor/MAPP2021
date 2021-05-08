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
    private int columnsOfBlocks;
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
        columnsOfBlocks = Mathf.CeilToInt(cameraWidth / spaceBetween);
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
            for (int i = 0; i <= columnsOfBlocks; i++)
            {
                lastBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * i), spawnHight), Quaternion.identity);
            }
        }
        else
        {
            for (int i = 0; i <= (columnsOfBlocks); i++)
            {
                lastBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * i) + (spaceBetween /2), spawnHight), Quaternion.identity);
            }

        }
        left = !left;
    }
    void FillScreen()
    {
        for (int row = 0; row <= rowsOfBlocks; row++)
        {
            for (int column = 0; column <= columnsOfBlocks; column++)
            {
                if (left)
                    lastBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * column), spawnHight - (spaceBetween / 2 * (rowsOfBlocks - row))), Quaternion.identity);
                else
                    lastBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * column) + (spaceBetween / 2), spawnHight - (spaceBetween / 2 * (rowsOfBlocks - row))), Quaternion.identity);

            }
            left = !left;
        }
    }
}
