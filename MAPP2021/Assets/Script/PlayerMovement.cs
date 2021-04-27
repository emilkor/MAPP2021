using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private float yAxis;
    private float xAxis;
    private Vector3 velocity;
    [SerializeField] private float defaultMovementSpeed = 10f;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private float movementYAxis = 5;
    private float resetYAxis;

    private float movementSpeed = 10f;

    // Start is called before the first frame update
    private void Awake()
    {
        resetYAxis = Input.acceleration.y;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        movementSpeed = defaultMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        yAxis = (Input.acceleration.y - resetYAxis)  * movementSpeed * movementYAxis;
        xAxis = Input.acceleration.x * movementSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -5f, 5f), Mathf.Clamp(transform.position.y, -9f, 9f));

        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, new Vector3(xAxis, yAxis), ref velocity, smoothTime);

        
        
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed *= speed;
    }

    public void ResetMovementSpeed()
    {
        movementSpeed = defaultMovementSpeed;
    }

}
