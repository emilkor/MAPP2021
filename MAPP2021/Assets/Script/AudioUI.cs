using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioUI : MonoBehaviour
{
    private AudioManager am;
    public AudioMixer musicMixer;

    public float fadeTo = 0f;
    public float fadeDuration = 2f;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        if (SceneManager.GetActiveScene().name.Equals("Level"))
        {
            StartCoroutine(FadeMixerGroup.StartFade(musicMixer, "MenuVolume", fadeDuration - 1f, fadeTo));
        }
    }

    public void PlayButtonPress()
    {
        am.Play("ButtonPress");
    }

    public void PlayStartButton()
    {
        am.Play("StartButton");
    }

    
    public void FadeOutMenu()
    {
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, "MenuVolume", fadeDuration, fadeTo));
    }

    public void RestoreMenuTheme()
    {
        musicMixer.SetFloat("MenuVolume", 0f);
    }
}
