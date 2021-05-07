using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOpacity : MonoBehaviour
{
    [SerializeField] Image powerUpImage;
    [SerializeField] private float opacity = 0.4f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color color = powerUpImage.color;

            color.a -= opacity;

            powerUpImage.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color color = powerUpImage.color;

            color.a += opacity;

            powerUpImage.color = color;
        }
    }

}
