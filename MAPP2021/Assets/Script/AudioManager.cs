using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public float fadeWaitForSecs;
    private List<Sound> toggledClips = new List<Sound>();

    private Animator anim;
    public RuntimeAnimatorController universalFade;
    //gör array av controllers?

    public bool pointCounterEnabled;
    public int playerScore;
    private string score;
    private int mode;
    private int scoreThreshold;
    public int initialScoreThreshold;
    public ToggleButton toggleMuteButton;
    private bool isMuted;

    public Sound[] sounds;

    void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        anim = gameObject.AddComponent<Animator>();

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.musicAnimator = anim;
            anim.runtimeAnimatorController = universalFade;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }

    private void Start()
    {
        Play("MenuTheme");
        scoreThreshold = initialScoreThreshold;
        mode = 0;
    }

    
    private void Update()
    {
        if (pointCounterEnabled)
        {
            try
            {
                score = FindObjectOfType<PointCounter>().getPoints();
                playerScore = Convert.ToInt32(score);
                if(playerScore == 0)
                {
                    scoreThreshold = initialScoreThreshold;
                }

                if(playerScore >= scoreThreshold)
                {
                    scoreThreshold += playerScore;
                    mode++;
                    SetFadeIO();
                }

            }
            catch(NullReferenceException e)
            {
                Debug.LogWarning("Point Counter has not been assigned to an object");
            }
        }
    }

    
    private void SetFadeIO()
    {
        Sound s = GetAudioclip("test");

        switch (mode)
        {
            case 1:
                //Sätt rätt fil i rätt mode
                print("Fading out...");
                StartCoroutine(FadeOut(s));
                break;
            case 2:
                print("Fading in...");
                StartCoroutine(FadeIn(s));
                break;
            case 3:
                print("Fading out...");
                StartCoroutine(FadeOut(s));
                break;
            case 4:
                print("Fading in...");
                StartCoroutine(FadeIn(s));
                break;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Ljudfilen hittades inte!");
            return;
        }
        s.source.Play();
    }

    public Sound GetAudioclip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Ljudfilen hittades inte!");
        }
        return s;
    }

    public void MuteAll()
    {
        foreach(Sound s in sounds)
        {
            if (!s.source.mute)
            {
                s.source.mute = true;
                toggledClips.Add(s);
                isMuted = true;
            }
        }
    }

    public void UnmuteAll()
    {
        foreach(Sound s in sounds)
        {
            if (s.source.mute && toggledClips.Contains(s))
            {
                s.source.mute = false;
                toggledClips.Remove(s);
                isMuted = false;
            }
        }
    }
    
    public IEnumerator FadeIn(Sound s)
    {
        s.musicAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeWaitForSecs);
    }

    public IEnumerator FadeOut(Sound s)
    {
        s.musicAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(fadeWaitForSecs);
    }

    //Kod att sätta in för att initiera ett önskat ljud. Man måste sätta in ljudfilens namn i parantesen.
    //FindObjectofType<AudioManager>().Play(NAME_OF_THE_CLIP_AS_STRING);
}
