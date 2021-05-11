using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem particleSystem;

    public BorderAudio borderAudio;

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver.setAlive(false);
        var main = particleSystem.main;
        main.useUnscaledTime = true;
        particleSystem.Play();
        spriteRenderer.enabled = false;
        Time.timeScale = 0f;

        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        borderAudio.Stop();
        FindObjectOfType<AudioUI>().RestoreGamePitch();
    }



}
