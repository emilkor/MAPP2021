using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private float xAxis;
    private float test;
    [SerializeField] float movementSpeed = 10f;
   


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            Vector3 newPosition = new Vector3(1f, 0f, 0f);
            gameObject.transform.Translate(newPosition * Time.deltaTime * movementSpeed);
        }

        if(Input.GetKey(KeyCode.A) == true)
        {
            Vector3 moveLeft = new Vector3(-1f, 0f, 0f);
            gameObject.transform.Translate(moveLeft * Time.deltaTime * movementSpeed);
        }
        /*
        xAxis = Input.acceleration.x * movementSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);

        */
    }

    private void FixedUpdate()
    {
        //rigidbody.velocity = new Vector2(xAxis, 0f);
    }
}
