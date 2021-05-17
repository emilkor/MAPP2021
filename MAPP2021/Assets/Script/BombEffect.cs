using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BombEffect : MonoBehaviour
{
    [SerializeField] private Image image;

    private float timer;

    public IEnumerator BombHasGoneOf(float seconds)
    {
        timer = 0.0f;

        while (timer >= 0)
        {
            image.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, timer));

            timer += Time.deltaTime / seconds;
            yield return null;
        }


    }
}
