using System;
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
    private PauseMenu pauseMenu;

    [Range(1f, 150f)]
    public float gamePitch;
    private float volumePitch;

    [Range(0f, 10000f)]
    public float pauseHiPass;

    public float fadeTo = 0f;
    public float fadeDuration;

    private bool isSlowed;
    private bool isRestored;
    private float basePitch = 1f;
    private float tempRestore;
    private float tempSet;

    private float tempPass;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        volumePitch = gamePitch / 100f;
        isRestored = true;
        tempRestore = basePitch;

        if (SceneManager.GetActiveScene().name.Equals("Level"))
        {
            pauseMenu = FindObjectOfType<PauseMenu>();
            am.Play("GameTheme");
            RestoreGameTheme();
            FadeOutMenu();
        }

        if (SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            RestoreMenuTheme();
            MuteGameTheme();
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

    public void PlayUnlockableButton()
    {
        am.Play("Unlockable");
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
        try
        {
            if (pauseMenu.GetIsPaused())
            {
                tempPass += (pauseHiPass - tempPass) * 0.01f;
                musicMixer.SetFloat("GameHiPass", tempPass);
            }
            else
            {
                musicMixer.SetFloat("GameHiPass", 0f);
            }
        }
        catch(NullReferenceException e)
        {
            //Debug.Log(e.Message);
        }
        

        if (isSlowed)
        {
            tempSet += (volumePitch - tempSet) * 0.04f;
            musicMixer.SetFloat("GamePitch", tempSet);
            SFXMixer.SetFloat("BorderPitch", tempSet);
        }

        if (isRestored)
        {
            tempRestore += (basePitch - tempRestore) * 0.04f;
            musicMixer.SetFloat("GamePitch", tempRestore);
            SFXMixer.SetFloat("BorderPitch", tempRestore);
        }
    }

    public void SetGamePitch()
    {
        musicMixer.GetFloat("GamePitch", out basePitch);
        tempSet = basePitch;

        isRestored = false;
        isSlowed = true;
    }

    public void RestoreGamePitch()
    {
        musicMixer.GetFloat("GamePitch", out tempRestore);

        RestoreGamePitchBools();
    }

    private void RestoreGamePitchBools()
    {
        isSlowed = false;
        isRestored = true;
    }

    public void RestartPitch()
    {
        if (isSlowed)
        {
            tempRestore = volumePitch;
        }
        else
        {
            tempRestore = basePitch;
        }

        RestoreGamePitchBools();
    }

    public void SetHiPass()
    {
        tempPass = 0f;
    }

}
