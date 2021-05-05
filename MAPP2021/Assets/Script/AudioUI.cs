using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioUI : MonoBehaviour
{
    private static float MIXER_MUTE = -80f;

    private AudioManager am;
    public AudioMixer musicMixer;

    public float fadeTo = 0f;
    public float fadeDuration;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();

        if (SceneManager.GetActiveScene().name.Equals("Level"))
        {
            FadeOutMenu();
        }

        if (SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            RestoreMenuTheme();
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
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, "MenuVolume", fadeDuration * 0.5f, fadeTo));
    }

    public void RestoreMenuTheme()
    {
        musicMixer.SetFloat("MenuVolume", 0f);
    }
}
