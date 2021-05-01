using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float cameraWidth = 6f;

    private float aspectRation;

    // Start is called before the first frame update
    void Awake()
    {
        aspectRation = camera.aspect;
        camera.orthographicSize = cameraWidth / aspectRation;
    }
}
