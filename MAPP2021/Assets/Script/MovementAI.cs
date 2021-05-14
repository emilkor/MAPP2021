using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class MovementAI : MonoBehaviour
{
    private RaycastHit2D[] raycastHit2D;
    private float cameraHight;
    private float cameraWidth;

    private Vector2 northEast;
    private Vector2 southEast;
    private Vector2 southWest;
    private Vector2 northWest;

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
        raycastHit2D[0] = Physics2D.Raycast((Vector2)transform.position + new Vector2(0, .5f), Vector2.up);
        raycastHit2D[1] = Physics2D.Raycast((Vector2)transform.position + new Vector2(0.5f, 0), northEast);
        raycastHit2D[2] = Physics2D.Raycast((Vector2)transform.position + new Vector2(0, -.5f), Vector2.right);
        raycastHit2D[3] = Physics2D.Raycast((Vector2)transform.position + new Vector2(-.5f, 0), Vector2.left);
        raycastHit2D[4] = Physics2D.Raycast((Vector2)transform.position + new Vector2(-.5f, 0), Vector2.left);
        raycastHit2D[5] = Physics2D.Raycast((Vector2)transform.position + new Vector2(-.5f, 0), Vector2.left);
        raycastHit2D[6] = Physics2D.Raycast((Vector2)transform.position + new Vector2(-.5f, 0), Vector2.left);
        raycastHit2D[7] = Physics2D.Raycast((Vector2)transform.position + new Vector2(-.5f, 0), Vector2.left);
    }
}
