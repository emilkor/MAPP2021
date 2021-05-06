using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBlocks : MonoBehaviour
{
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
    private bool gettingBigger;
    private Quaternion fromAngle;
    private Quaternion toAngle;
    private Vector2 targetPosition;

    // Start is called before the first frame update

    void Start()
    {
        deathPosition = -(Camera.main.orthographicSize + Mathf.Sqrt(Mathf.Pow(maxSize, 2) / 2));
        targetPosition = new Vector2(gameObject.transform.position.x, deathPosition);
        //speed = blockSpeed.GetSpeed() * percentOfOtherBlocks;
        speed = 1;
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

        if (transform.position.y <= deathPosition)
        {
            Destroy(gameObject);
        }


    }

    public float GetMaxSize()
    {
        return maxSize;
    }

    public float GetTimer()
    {
        return time;
    }

    public void SetTimer(float time)
    {
        Debug.Log(time);
        this.time = time;
        
    }

    public bool GetGettingBigger()
    {
        return gettingBigger;
    }

    public void SetGettingBigger(bool gettingBigger)
    {
        this.gettingBigger = gettingBigger;
    }

    public void SetAngle(Quaternion rotation)
    {
        int i = (int)rotation.eulerAngles.z / 45;
        Debug.Log(i);
        fromAngle = Quaternion.Euler(new Vector3(0, 0, 45 * (i +1)));
        toAngle = Quaternion.Euler(fromAngle.eulerAngles + (Vector3.forward * 45));
    }

}
