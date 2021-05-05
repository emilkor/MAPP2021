using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private BackgroundBlocks blocksScript;
    [SerializeField] private int spawnHight;


    private float spaceBetween;
    private float cameraWidth;
    private int colomOfBlocks;
    private GameObject currentBlock;
    private GameObject lastBlock;

    private bool left;


    // Start is called before the first frame update
    void Start()
    {
        spaceBetween = blocksScript.GetMaxSize() * 2;
        cameraWidth = (float) Camera.main.orthographicSize * Camera.main.aspect * 2;
        colomOfBlocks = Mathf.CeilToInt(cameraWidth / spaceBetween);
        SpawnFirstRow();
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
                currentBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * i), spawnHight), lastBlock.transform.rotation);
                //currentBlock.GetComponent<BackgroundBlocks>().SetTimer(lastBlock.GetComponent<BackgroundBlocks>().GetTimer());
                currentBlock.GetComponent<BackgroundBlocks>().SetGettingBigger(lastBlock.GetComponent<BackgroundBlocks>().GetGettingBigger());
                //currentBlock.GetComponent<BackgroundBlocks>().SetAngle(lastBlock.transform.rotation);
            }
        }
        else
        {
            for (int i = 0; i <= colomOfBlocks; i++)
            {
                currentBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * i) + (spaceBetween /2), spawnHight), lastBlock.transform.rotation);
                //currentBlock.GetComponent<BackgroundBlocks>().SetTimer(lastBlock.GetComponent<BackgroundBlocks>().GetTimer());
                currentBlock.GetComponent<BackgroundBlocks>().SetGettingBigger(lastBlock.GetComponent<BackgroundBlocks>().GetGettingBigger());
                //currentBlock.GetComponent<BackgroundBlocks>().SetAngle(lastBlock.transform.rotation);
            }

        }
        lastBlock = currentBlock;

        left = !left;
    }
    void SpawnFirstRow()
    {
        
    
        for (int i = 0; i <= colomOfBlocks; i++)
        {
            lastBlock = Instantiate(block, new Vector2((-cameraWidth / 2) + (spaceBetween * i), spawnHight), Quaternion.identity);
        }
        
        
    }
}
