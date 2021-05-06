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
    [SerializeField] private float durationIn = 1f;

    [SerializeField] private float fadeAway = 0f;
    [SerializeField] private float durationOut = 1f;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        am.Play("BorderAudio");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        am.Play("BorderImpact");


        FadeInGrind();

        //am.Play("BorderAudio");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(fadeIn);

        FadeOutGrind();

        //am.Stop("BorderAudio");
    }

    public void FadeInGrind()
    {
        fadeIn = StartCoroutine(FadeMixerGroup.StartFade(SFXMixer, "GrindVolume", durationIn, fadeEnter));
    }

    public void FadeOutGrind()
    {
        fadeOut = StartCoroutine(FadeMixerGroup.StartFade(SFXMixer, "GrindVolume", durationOut, fadeAway));
    }
}
