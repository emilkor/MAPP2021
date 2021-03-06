using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBlocks : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float minSize = 1.5f;
    [SerializeField] private float maxSize = 3f;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float secondsChangingSize;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private static BackgroundBlocks lastOne;

    private static float size;
    private static float time;
    private static bool gettingBigger;
    private static Quaternion fromAngle = Quaternion.identity;
    private static Quaternion toAngle = Quaternion.Euler(fromAngle.eulerAngles + (Vector3.forward * 45));
    private Vector2 targetPosition;
    private float deathPosition;
    private static bool colliderOn;
    private static bool cykelOfColliderOn;
    private static bool continueColorChange;



    // Start is called before the first frame update

    void Awake()
    {
        if (lastOne != null)
        {
            boxCollider.enabled = lastOne.boxCollider.enabled;
            if (lastOne.boxCollider.enabled == true)
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }
        }
    }

    void Start()
    {
        
        deathPosition = -(Camera.main.orthographicSize + Mathf.Sqrt(Mathf.Pow(maxSize, 2) / 2));
        targetPosition = new Vector2(gameObject.transform.position.x, deathPosition);
        
        if (lastOne == null)
        {
            StartCoroutine(Varibuls(secondsChangingSize));
        }
        lastOne = this;

    }

    static IEnumerator Varibuls(float secondsChangingSize)
    {
        time += Time.deltaTime / secondsChangingSize;
        if (time >= 1)
        {
            gettingBigger = !gettingBigger;
            time = 0;
            fromAngle = toAngle;
            toAngle = Quaternion.Euler(fromAngle.eulerAngles + (Vector3.forward * 45));
        }
        yield return null;

        lastOne.StartCoroutine(Varibuls(lastOne.secondsChangingSize));
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);
        

        if (gettingBigger)
        {
            size = Mathf.Lerp(minSize, maxSize, time);
        }
        else
        {
            size = Mathf.Lerp(maxSize, minSize, time);
        }
       
        transform.localScale = new Vector3(size, size);
        transform.rotation = Quaternion.Lerp(fromAngle, toAngle, time);

        if (transform.position.y <= deathPosition)
        {
            Destroy(gameObject);
        }
        if (colliderOn)
        {
            Debug.Log(boxCollider.enabled);
            if (GameObject.Find("Block") == null && gettingBigger && time > .95f)
            {
                boxCollider.enabled = true;
                continueColorChange = false;
            }
            else if ((!boxCollider.enabled && cykelOfColliderOn != gettingBigger) || continueColorChange)
            {
                continueColorChange = true;
                spriteRenderer.color = new Color((size - minSize) / (maxSize-minSize), (size - minSize) / (maxSize - minSize), (size - minSize) / (maxSize - minSize), (((size - minSize) / (maxSize - minSize)) * .5f) + .5f);
                 
            }
        }
        else
        {
            boxCollider.enabled = false; 
        }


    }

    public float GetMaxSize()
    {
        return maxSize;
    }

    public static void MakeBackgroundSolid()
    {

        colliderOn = true;
        cykelOfColliderOn = gettingBigger;
    }

    public static void MakeBackgroundUnsolid()
    { 
        colliderOn = false;
    }

}
