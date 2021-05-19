using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private GameObject light;

    public BorderAudio borderAudio;

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver.SetAlive(false);
        var main = particleSystem.main;
        main.useUnscaledTime = true;
        particleSystem.Play();
        spriteRenderer.enabled = false;
        trail.enabled = false;
        light.SetActive(false);
        Time.timeScale = 0f;

        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        borderAudio.Stop();
        FindObjectOfType<AudioUI>().RestoreGamePitch();
    }



}
