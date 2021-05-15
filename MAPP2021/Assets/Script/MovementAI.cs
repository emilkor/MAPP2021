using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class MovementAI : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float smoothTime = 0.3f;

    private RaycastHit2D[] raycastHit2D = new RaycastHit2D[8];

    private float cameraHight;
    private float cameraWidth;

    private Vector2 northEast;
    private Vector2 southEast;
    private Vector2 southWest;
    private Vector2 northWest;

    private Vector2 travelDirektion;
    private float shortest;

    private Vector2 velocity;


    // Start is called before the first frame update
    void Start()
    {
        cameraHight = Camera.main.orthographicSize;
        cameraWidth = cameraHight * Camera.main.aspect;
        northEast = (Vector2.up + Vector2.left).normalized;
        southEast = (Vector2.left + Vector2.down).normalized;
        southWest = (Vector2.down + Vector2.right).normalized;
        northWest = (Vector2.right + Vector2.up).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        raycastHit2D[0] = Physics2D.Raycast((Vector2)transform.position + (Vector2.up * .5f), Vector2.up/*, cameraHight - ((Vector2)transform.position + (Vector2.up * .5f)).y*/);
        raycastHit2D[2] = Physics2D.Raycast((Vector2)transform.position + (Vector2.right * .5f), Vector2.right);
        raycastHit2D[4] = Physics2D.Raycast((Vector2)transform.position + (Vector2.down * .5f), Vector2.down);
        raycastHit2D[6] = Physics2D.Raycast((Vector2)transform.position + (Vector2.left * .5f), Vector2.left/*, Mathf.Abs(-cameraHight - ((Vector2)transform.position + (Vector2.up * .5f)).y)*/);


        raycastHit2D[1] = Physics2D.Raycast((Vector2)transform.position + (northEast * .5f), northEast);
        raycastHit2D[3] = Physics2D.Raycast((Vector2)transform.position + (southEast * .5f), southEast);
        raycastHit2D[5] = Physics2D.Raycast((Vector2)transform.position + (southWest * .5f), southWest);
        raycastHit2D[7] = Physics2D.Raycast((Vector2)transform.position + (northWest * .5f), northWest);


        shortest = Mathf.Infinity;
        for (int i = 0; i < raycastHit2D.Length; i++)
        {
            //Debug.Log(raycastHit2D[1] == true);
            
        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -cameraWidth, cameraWidth), Mathf.Clamp(transform.position.y, -cameraHight, cameraHight));

        rigidbody.velocity = Vector2.SmoothDamp(rigidbody.velocity, travelDirektion, ref velocity, smoothTime);
    }
}
