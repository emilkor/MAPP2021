using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameOver.setAlive(false);
        Time.timeScale = 0f;
    }
}
