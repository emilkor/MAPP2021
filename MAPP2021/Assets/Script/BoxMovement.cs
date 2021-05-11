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
    private bool blownUp;
    private float cameraHight;

    // Start is called before the first frame update

    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        blockSpeed = GameObject.FindWithTag("Speed").GetComponent<BlockSpeed>();
        deathPosition = -(Camera.main.orthographicSize + (transform.localScale.y / 2));
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
        
        
            if (gameObject.transform.position.y == deathPosition)
            {
                Destroy(gameObject);
            }
        
    }

    public Vector2 getTarget()
    {
        return targetPosition;
    }

    public void BlowingUp(Transform player, float explotionSpeed)
    {
        blownUp = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //rak linje y = mx + b
        float m = (gameObject.transform.position.y - player.position.y) / (gameObject.transform.position.x - player.position.x);
        float b = -((m * player.position.x) - player.position.y);
        float x = gameObject.transform.position.x >= player.position.x ? 100 : -100;
        float y = (m * x) + b;
        targetPosition = new Vector2(x, y);
        speed = explotionSpeed;
        StartCoroutine(DestroyTimer());
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
