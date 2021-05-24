using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private float yAxis;
    private float xAxis;
    private float yAxisPC;
    private float xAxisPC;
    private Vector3 velocity;
    [SerializeField] private float defaultMovementSpeed = 10f;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private float movementYAxis = 5;
    private float resetYAxis;

    private float movementSpeed = 10f;
    private float cameraHight;
    private float cameraWidth;

    // Start is called before the first frame update
    private void Awake()
    {
        resetYAxis = Input.acceleration.y;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        movementSpeed = defaultMovementSpeed;
        cameraHight = (float) (Camera.main.orthographicSize - 0.5);
        cameraWidth = (float) ((Camera.main.orthographicSize * Camera.main.aspect) - 0.5);
    }

    // Update is called once per frame
    void Update()
    {
        
        yAxis = (Input.acceleration.y - resetYAxis)  * movementSpeed * movementYAxis;
        xAxis = Input.acceleration.x * movementSpeed;
        yAxisPC = Input.GetAxis("Vertical") * movementSpeed/3;
        xAxisPC = Input.GetAxis("Horizontal") * movementSpeed/3;


        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -cameraWidth, cameraWidth), Mathf.Clamp(transform.position.y, -cameraHight, cameraHight));

        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, new Vector3(xAxis + xAxisPC, yAxis + yAxisPC), ref velocity, smoothTime);

        
        
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
