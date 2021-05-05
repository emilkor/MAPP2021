using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    private BlockSpeed blockSpeed;
    private Spawner spawner;
    [SerializeField] private float speed;
    [SerializeField] private float deathPosition;
    

    private Vector2 targetPosition;

    // Start is called before the first frame update

    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        blockSpeed = GameObject.FindWithTag("Speed").GetComponent<BlockSpeed>();
        deathPosition = -spawner.GetHightOfSpawnPosition();
        targetPosition = new Vector2(gameObject.transform.position.x, deathPosition);
        speed = blockSpeed.GetSpeed();  
    }

    // Update is called once per frame
    //static void Update()
    //{
       

    //}


    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);
        if ((Vector2)gameObject.transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }

    public Vector2 getTarget()
    {
        return targetPosition;
    }

}
