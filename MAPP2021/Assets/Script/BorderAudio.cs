using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BorderAudio : MonoBehaviour
{

    public AudioMixer SFXMixer;
    private AudioManager am;

    private Coroutine fadeOut;
    private Coroutine fadeIn;

    [SerializeField] private float fadeEnter = 1f;
    [SerializeField] private float durationIn = 0.1f;

    [SerializeField] private float fadeAway = 0f;
    [SerializeField] private float durationOut = 0.15f;

    
 
    private bool isPlaying;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        am.Play("BorderAudio");
    }

    private void Update()
    {
        if (FindObjectOfType<WallGrinding>().GetIsTouching())
        {
            if (!isPlaying)
            {
                isPlaying = true;
                PlayGrind();
            }
        }
        else
        {
            if (isPlaying)
            {
                StopGrind();
                isPlaying = false;
            }
        }
    }

    public void PlayGrind()
    {
        am.Play("BorderImpact");
        FadeInGrind();
    }

    public void StopGrind()
    {
        StopCoroutine(fadeIn);

        FadeOutGrind();
    }

    public void FadeInGrind()
    {
        fadeIn = StartCoroutine(FadeMixerGroup.StartFade(SFXMixer, "GrindVolume", durationIn, fadeEnter));
    }

    public void FadeOutGrind()
    {
        fadeOut = StartCoroutine(FadeMixerGroup.StartFade(SFXMixer, "GrindVolume", durationOut, fadeAway));
    }

    public void Stop()
    {
        SFXMixer.SetFloat("GrindVolume", -80f);
    }
}
