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

    private float lengthToTop;
    private float lengthToRight;
    private float lengthToBottom;
    private float lengthToLeft;
    private float lengthToNorthEast;
    private float lengthToSouthEast;
    private float lengthToSouthWest;
    private float lengthToNorthWest;


    private Vector2 travelDirektion;
    private float shortestLength;
    private int shortestIndex;

    private float rightSide;
    private float leftSide;

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
    //void Update()
    //{
        
    //}

    void FixedUpdate()
    {
        lengthToTop = cameraHight - ((Vector2)transform.position + (Vector2.up * .5f)).y;
        lengthToRight = cameraWidth - ((Vector2)transform.position + (Vector2.right * .5f)).x;
        lengthToBottom = Mathf.Abs(-cameraHight - ((Vector2)transform.position + (Vector2.down * .5f)).y);
        lengthToLeft = Mathf.Abs(-cameraWidth - ((Vector2)transform.position + (Vector2.left * .5f)).x);

        lengthToNorthEast = lengthToTop < lengthToRight ? Mathf.Sqrt(Mathf.Pow(lengthToTop + .5f, 2) * 2) - .5f :
            Mathf.Sqrt(Mathf.Pow(lengthToRight + .5f, 2) * 2) - .5f;

        lengthToSouthEast = lengthToRight < lengthToBottom ? Mathf.Sqrt(Mathf.Pow(lengthToRight + .5f, 2) * 2) - .5f :
            Mathf.Abs(Mathf.Sqrt(Mathf.Pow(lengthToBottom + .5f, 2) * 2) - .5f);

        lengthToSouthWest = lengthToBottom < lengthToLeft ? Mathf.Abs(Mathf.Sqrt(Mathf.Pow(lengthToBottom + .5f, 2) * 2) - .5f) :
            Mathf.Abs(Mathf.Sqrt(Mathf.Pow(lengthToLeft + .5f, 2) * 2) - .5f);

        lengthToNorthWest = lengthToLeft < lengthToTop ? Mathf.Abs(Mathf.Sqrt(Mathf.Pow(lengthToLeft + .5f, 2) * 2) - .5f) :
            Mathf.Sqrt(Mathf.Pow(lengthToTop + .5f, 2) * 2) - .5f;




        raycastHit2D[0] = Physics2D.Raycast((Vector2)transform.position + (Vector2.up * .5f), Vector2.up, lengthToTop);
        raycastHit2D[2] = Physics2D.Raycast((Vector2)transform.position + (Vector2.right * .5f), Vector2.right, lengthToRight);
        raycastHit2D[4] = Physics2D.Raycast((Vector2)transform.position + (Vector2.down * .5f), Vector2.down, lengthToBottom);
        raycastHit2D[6] = Physics2D.Raycast((Vector2)transform.position + (Vector2.left * .5f), Vector2.left, lengthToLeft);

        
        raycastHit2D[1] = Physics2D.Raycast((Vector2)transform.position + (northEast * .5f), northEast, lengthToNorthEast);
        raycastHit2D[3] = Physics2D.Raycast((Vector2)transform.position + (northEast * .5f), northEast, lengthToSouthEast);
        raycastHit2D[5] = Physics2D.Raycast((Vector2)transform.position + (northEast * .5f), northEast, lengthToSouthWest);
        raycastHit2D[7] = Physics2D.Raycast((Vector2)transform.position + (northEast * .5f), northEast, lengthToNorthWest);
        
        
        

        shortestLength = Mathf.Infinity;
        for (int i = 0; i < raycastHit2D.Length; i++)
        {
            if (raycastHit2D[i] && raycastHit2D[i].distance < shortestLength)
            {
                shortestLength = raycastHit2D[i].distance;
                shortestIndex = i;
            }   
        }

        rightSide = GetLength(GetIndex(shortestIndex - 2)) + GetLength(GetIndex(shortestIndex - 3));
        leftSide = GetLength(GetIndex(shortestIndex + 2)) + GetLength(GetIndex(shortestIndex + 3));

        if (rightSide > leftSide)
        {
            travelDirektion = (raycastHit2D[GetIndex(shortestIndex - 2)].point + raycastHit2D[GetIndex(shortestIndex - 3)].point + raycastHit2D[GetIndex(shortestIndex - 4)].point).normalized;
        }
        else
        {
            travelDirektion = (raycastHit2D[GetIndex(shortestIndex + 2)].point + raycastHit2D[GetIndex(shortestIndex + 3)].point + raycastHit2D[GetIndex(shortestIndex + 4)].point).normalized;
        }



        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -(cameraWidth - .5f), cameraWidth - .5f), Mathf.Clamp(transform.position.y, -(cameraHight - .5f), cameraHight - .5f));

        rigidbody.velocity = Vector2.SmoothDamp(rigidbody.velocity, travelDirektion, ref velocity, smoothTime);

    }

    private int GetIndex(int index)
    {
        if (index < 0)
        {
            return 8 + index;
        }
        if (index > 7)
        {
            return index - 8;
        }
        return index;
    }

    private float GetLength(int index)
    {
        if (raycastHit2D[index].distance != 0)
        {
            return raycastHit2D[index].distance;
        }
        switch (index){
            case 0:
                return lengthToTop;
            case 1:
                return lengthToNorthEast;
            case 2:
                return lengthToRight;
            case 3:
                return lengthToSouthEast;
            case 4:
                return lengthToBottom;
            case 5:
                return lengthToSouthWest;
            case 6:
                return lengthToLeft;
            case 7:
                return lengthToNorthWest;
            default:
                return raycastHit2D[index].distance;
        }
    }

}
