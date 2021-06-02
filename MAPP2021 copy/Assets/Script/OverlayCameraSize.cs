using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayCameraSize : MonoBehaviour
{

    [SerializeField] private RectTransform canvas;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = canvas.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
