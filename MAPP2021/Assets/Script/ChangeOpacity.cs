using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOpacity : MonoBehaviour
{
    [SerializeField] Image powerUpImage;
    private float speed = 0.4f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color color = powerUpImage.color;

            color.a -= speed;

            powerUpImage.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color color = powerUpImage.color;

            color.a += speed;

            powerUpImage.color = color;
        }
    }

}
