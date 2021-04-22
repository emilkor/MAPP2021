using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private int timeStopTime;

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameOver.setAlive(false);
        var main = particleSystem.main;
        main.useUnscaledTime = true;
        particleSystem.Play();
        spriteRenderer.enabled = false;
        Time.timeScale = 0f;

    }


}
