using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private static float speed;
    [SerializeField] private static float deathPosition = -10;
    [SerializeField] private BlockSpeed blockSpeed;

    private Vector2 targetPosition;

    // Start is called before the first frame update

    void Start()
    {
        targetPosition = new Vector2(gameObject.transform.position.x, deathPosition);
        speed = blockSpeed.GetSpeed();
    }

    // Update is called once per frame
    static void Update()
    {
       

    }


    void FixedUpdate()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.fixedDeltaTime);
        if ((Vector2)gameObject.transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }
}
