using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingBody : MonoBehaviour
{
    [SerializeField] private GameObject[] blinkingBody;
    [SerializeField] private float blinkingTime;

    private SpriteRenderer[] blinkingColor;

    private float[] timer;
    private float bodySize;
    private float colorTransparency;
    private float spreadOfBlinkers;


    void Start()
    {
        spreadOfBlinkers = 1f / blinkingBody.Length;
        timer = new float[blinkingBody.Length];
        blinkingColor = new SpriteRenderer[blinkingBody.Length];
        for (int i = 0; i < blinkingBody.Length; i++)
        {
            timer[i] = spreadOfBlinkers * i;
            blinkingColor[i] = blinkingBody[i].GetComponent<SpriteRenderer>();
        }
        Debug.Log(spreadOfBlinkers);
    }

    // Update is called once per frame
    void Update()
    {
        timer[0] = (timer[0] + (Time.deltaTime / blinkingTime)) % 1f;

        for (int i = 1; i < timer.Length; i++)
        {
            timer[i] = (timer[0] + (spreadOfBlinkers * i)) % 1f;
        }
        for (int i = 0; i < blinkingBody.Length; i++)
        {
            bodySize = Mathf.Lerp(0, 1, timer[i]);
            colorTransparency = Mathf.Lerp(1, 0, timer[i]);
            blinkingBody[i].transform.localScale = new Vector3(bodySize, bodySize);
            blinkingColor[i].color = new Color(1, 1, 1, colorTransparency);
            Debug.Log(timer[i]);
        }
        
    }
}
