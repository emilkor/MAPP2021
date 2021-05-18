using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    private BlockSpeed blockSpeed;
    private Spawner spawner;
    [SerializeField] private float speed;
    [SerializeField] private float deathPosition;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody;


    private Vector2 targetPosition;

    private double timer;
    

    // Start is called before the first frame update

    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        blockSpeed = GameObject.FindWithTag("Speed").GetComponent<BlockSpeed>();
        deathPosition = -(Camera.main.orthographicSize + (transform.localScale.y / 2));
        targetPosition = new Vector2(gameObject.transform.position.x, deathPosition);
        speed = blockSpeed.GetSpeed();
        rigidbody.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    //static void Update()
    //{
       

    //}


    void Update()
    {
        //timer += Time.deltaTime;
        //gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);
        
        
        if (gameObject.transform.position.y <= deathPosition)
        {
            //Debug.Log(timer);
            Destroy(gameObject);
        }

        
    }

    public Vector2 getTarget()
    {
        return targetPosition;
    }

    public void BlowingUp(/*Transform player, float explotionSpeed,*/ float blockParticulsPerSquearUnit)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //rak linje y = mx + b
        this.enabled = false;
        //float m = (gameObject.transform.position.y - player.position.y) / (gameObject.transform.position.x - player.position.x);
        //float b = -((m * player.position.x) - player.position.y);
        //float x = gameObject.transform.position.x >= player.position.x ? 100 : -100;
        //float y = (m * x) + b;
        //rigidbody2D.simulated = true;
        //rigidbody2D.AddForce(new Vector2(x/(Mathf.Abs(x) + Mathf.Abs(y)) * explotionSpeed, y / (Mathf.Abs(x) + Mathf.Abs(y)) * explotionSpeed));
        var e = particleSystem.emission;
        e.rateOverTime = transform.localScale.x * transform.localScale.y * blockParticulsPerSquearUnit;
        particleSystem.Play();
        spriteRenderer.enabled = false;
        StartCoroutine(DestroyTimer());
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
