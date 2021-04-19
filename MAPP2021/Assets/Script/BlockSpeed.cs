using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpeed : MonoBehaviour
{
    [SerializeField] private float startSpeed = 3f;
    [SerializeField] private float maxTimesFaster = 4f;
    [SerializeField] private float acceleration = 10f;

    [SerializeField] private float speed;
    private static float timer;

    // Start is called before the first frame update
    void Awake()
    {
        speed = startSpeed;
        timer = acceleration / (maxTimesFaster - 1);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        timer += Time.fixedDeltaTime;
        speed = startSpeed * ((acceleration / -timer) + maxTimesFaster);
    }

    public float GetSpeed()
    {
        return speed;
    }
}
