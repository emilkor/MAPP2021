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

    public IEnumerator ShakeCamera(float dutation, float magnitud)
    {
        originalPos = transform.position;
        timer = 0.0f;

        while (timer < dutation)
        {
            x = Random.Range(Mathf.Lerp(-1f, 0f, timer/dutation), Mathf.Lerp(1f, 0, timer / dutation)) * magnitud;
            y = Random.Range(Mathf.Lerp(-1f, 0f, timer / dutation), Mathf.Lerp(1f, 0, timer / dutation)) * magnitud;

            transform.position = new Vector3(x, y, -10);

            timer += Time.deltaTime;

            yield return null;
        }
        transform.position = originalPos;
    }
}
