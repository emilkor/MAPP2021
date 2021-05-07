using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{

    [SerializeField] private Sprite wallBreak;
    [SerializeField] private Sprite explosion;
    [SerializeField] private Sprite slowMotion;

    [SerializeField] private Image powerUpImage;



    public void setSprite (PowerUp powerUp)
    {
        if(powerUp.Equals(PowerUp.Bomb))
        {
            powerUpImage.sprite = explosion;
        }

        else if (powerUp.Equals(PowerUp.SlowMotion))
        {
            powerUpImage.sprite = slowMotion;
        }

        else
        {
            powerUpImage.sprite = wallBreak;
        }
    }
   
}
