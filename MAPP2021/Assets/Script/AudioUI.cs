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
    public AudioMixer SFXMixer;

    [Range(1f, 150f)]
    public float gamePitch;
    private float volumePitch;

    public float fadeTo = 0f;
    public float fadeDuration;

    private bool isSlowed;
    private bool isRestored;
    private float basePitch;
    private float tempRestore;
    private float tempSet;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        volumePitch = gamePitch / 100f;

        if (SceneManager.GetActiveScene().name.Equals("Level"))
        {
            am.Play("GameTheme");
            RestoreGameTheme();
            FadeOutMenu();
        }

        if (SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            RestoreMenuTheme();
            MuteGameTheme();
            //FadeOutGame();
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

    public void FadeOutGame()
    {
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, "GameVolume", fadeDuration * 0.1f, fadeTo));
    }

    public void FadeOutBorder()
    {
        StartCoroutine(FadeMixerGroup.StartFade(SFXMixer, "GrindVolume", fadeDuration * 0.2f, fadeTo));
    }

    public void RestoreMenuTheme()
    {
        musicMixer.SetFloat("MenuVolume", 0f);
        FadeOutBorder();
    }

    public void RestoreGameTheme()
    {
        musicMixer.SetFloat("GameVolume", 0f);
    }

    public void MuteGameTheme()
    {
        musicMixer.SetFloat("GameVolume", -80f);
    }

    private void Update()
    {
        if (isSlowed)
        {
            tempSet += (volumePitch - tempSet) * 0.05f;
            musicMixer.SetFloat("GamePitch", tempSet);
        }

        if (isRestored)
        {
            tempRestore += (basePitch - tempRestore) * 0.05f;
            print("base: " + basePitch);
            print("temp: " + tempRestore);
            musicMixer.SetFloat("GamePitch", tempRestore);
        }
    }

    public void SetGamePitch()
    {
        //musicMixer.SetFloat("GamePitch", volumePitch);
        musicMixer.GetFloat("GamePitch", out basePitch);
        tempSet = basePitch;

        isRestored = false;
        isSlowed = true;
    }

    public void RestoreGamePitch()
    {
        //musicMixer.SetFloat("GamePitch", 1f);
        musicMixer.GetFloat("GamePitch", out tempRestore);

        isSlowed = false;
        isRestored = true;
    }
}
