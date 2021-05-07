using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGrinding : MonoBehaviour
{
    [SerializeField] private ParticleSystem top;
    [SerializeField] private ParticleSystem right;
    [SerializeField] private ParticleSystem bottom;
    [SerializeField] private ParticleSystem left;

    private bool isTouching;

    private float cameraHight;
    private float cameraWidth;

    // Start is called before the first frame update
    void Start()
    {
        cameraHight = (float)(Camera.main.orthographicSize - 0.5);
        cameraWidth = (float)((Camera.main.orthographicSize * Camera.main.aspect) - 0.5);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y >= cameraHight)
        {
            top.Play();
        }
        else
        {
            top.Stop();
        }
        if (gameObject.transform.position.x >= cameraWidth)
        {
            right.Play();
        }
        else
        {
            right.Stop();
        }
        if (gameObject.transform.position.y <= -cameraHight)
        {
            bottom.Play();
        }
        else
        {
            bottom.Stop();
        }
        if (gameObject.transform.position.x <= -cameraWidth)
        {
            left.Play();
        }
        else
        {
            left.Stop();
        }       

        if(top.isPlaying || bottom.isPlaying || left.isPlaying || right.isPlaying)
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }

    public bool GetIsTouching()
    {
        return isTouching;
    }
}
