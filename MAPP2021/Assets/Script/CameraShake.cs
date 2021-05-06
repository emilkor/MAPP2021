using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPos;
    private float timer;
    private float x;
    private float y;
    private int counter;
    private Vector3 velocity = Vector3.zero;

    public IEnumerator ShakeCamera(float dutation, float magnitud, int deltaTimePerShake)
    {
        originalPos = transform.position;
        timer = 0.0f;
        counter = 0;

        while (timer < dutation)
        {
            if (counter % deltaTimePerShake == 0)
            {
                x = Random.Range(Mathf.Lerp(-1f, 0f, timer / dutation), Mathf.Lerp(1f, 0, timer / dutation)) * magnitud;
                y = Random.Range(Mathf.Lerp(-1f, 0f, timer / dutation), Mathf.Lerp(1f, 0, timer / dutation)) * magnitud;
            }

            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(x, y, -10), ref velocity, Time.deltaTime * deltaTimePerShake);

            timer += Time.deltaTime;
            counter++;

            yield return null;
        }
        transform.position = originalPos;
    }
}
