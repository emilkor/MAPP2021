using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBlocks : MonoBehaviour
{
    private BlockSpeed blockSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float deathPosition;
    [Range(0, 1f)]
    [SerializeField] private float percentOfOtherBlocks;

    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    [SerializeField] private float secondsChangingSize;

    private float size;
    private float time;
    private bool gettingBigger = true;
    private Quaternion fromAngle;
    private Quaternion toAngle;
    private Vector2 targetPosition;

    // Start is called before the first frame update

    void Start()
    {
        blockSpeed = GameObject.FindWithTag("Speed").GetComponent<BlockSpeed>();
        targetPosition = new Vector2(gameObject.transform.position.x, deathPosition);
        speed = blockSpeed.GetSpeed() * percentOfOtherBlocks;
        fromAngle = transform.rotation;
        toAngle = Quaternion.Euler(transform.eulerAngles + (Vector3.forward * 45));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime / secondsChangingSize;
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * (Time.deltaTime * secondsChangingSize));

        if (gettingBigger)
        {
            size = Mathf.Lerp(minSize, maxSize, time);
        }
        else
        {
            size = Mathf.Lerp(maxSize, minSize, time);
        }
        if(time >= 1)
        {
            gettingBigger = !gettingBigger;
            time = 0;
            fromAngle = transform.rotation;
            toAngle = Quaternion.Euler(transform.eulerAngles + (Vector3.forward * 45));
        }
        transform.localScale = new Vector3(size, size);
        transform.rotation = Quaternion.Lerp(fromAngle, toAngle, time);


    }
}
