using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class MovementAI : MonoBehaviour
{
    private RaycastHit2D[] raycastHit2D;
    private RaycastHit2D northEastDistance;
    private RaycastHit2D eastDistance;
    private RaycastHit2D southEastDistance;
    private RaycastHit2D southDistance;
    private RaycastHit2D southWestDistance;
    private RaycastHit2D westDistance;
    private RaycastHit2D northWestDistance;
    private float cameraHight;
    private float cameraWidth;

    // Start is called before the first frame update
    void Start()
    {
        cameraHight = Camera.main.orthographicSize;
        cameraWidth = cameraHight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        raycastHit2D[0] = Physics2D.Raycast((Vector2)transform.position + new Vector2(0, .5f), Vector2.up);
        eastDistance = Physics2D.Raycast((Vector2)transform.position + new Vector2(0.5f, 0), Vector2.right);
        southDistance = Physics2D.Raycast((Vector2)transform.position + new Vector2(0, -.5f), Vector2.down);
        westDistance = Physics2D.Raycast((Vector2)transform.position + new Vector2(-.5f, 0), Vector2.left);
    }
}
