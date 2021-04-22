using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private float yAxis;
    private float xAxis;
    private Vector2 velocity;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float smoothTime = 0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        yAxis = Input.acceleration.y * movementSpeed;
        xAxis = Input.acceleration.x * movementSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9f, 9f), transform.position.y);

        
        rigidbody.velocity = Vector2.SmoothDamp(rigidbody.velocity, new Vector2(xAxis, yAxis), ref velocity, smoothTime);
        //rigidbody.AddForce(velocity);
    }

 
}
