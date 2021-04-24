using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public float fadeWaitForSecs;
    private int muteCounter = 0;
    private List<Sound> toggledClips = new List<Sound>();

    private Animator anim;
    public RuntimeAnimatorController universalFade;

    //public int playerScore;
    //private string score;
    //private int mode;
    //public int scoreThreshold;

    public Sound[] sounds;

    // Start is called before the first frame update
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

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            anim = gameObject.GetComponent<Animator>();
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
        Play("test");
        //mode = 0;
    }

    /*
    private void Update()
    {
        score = FindObjectOfType<PointCounter>().getPoints();
        playerScore = Convert.ToInt32(score);

        if(playerScore >= scoreThreshold)
        {
            scoreThreshold += playerScore;
            mode++;
            SetFadeIO();
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
        }
    }*/

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

    public void ToggleMuteAll()
    {
        muteCounter++;

        foreach(Sound s in sounds)
        {
            if(muteCounter % 2 == 1)
            {
                if (!s.source.mute)
                {
                    s.source.mute = true;
                    toggledClips.Add(s);
                }
            }
            else
            {
                if (s.source.mute && toggledClips.Contains(s))
                {
                    s.source.mute = false;
                    toggledClips.Remove(s);
                }
            }
            
        }

        //lägg till kod för att toggla muted clips!
    }


    public void PlayButtonHover()
    {
        Play("ButtonHover");
    }

    /*
    IEnumerator FadeIn(Sound s)
    {
        s.musicAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeWaitForSecs);
    }

    IEnumerator FadeOut(Sound s)
    {
        s.musicAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeWaitForSecs);
    }*/

    //Kod att sätta in för att initiera ett önskat ljud. Man måste sätta in ljudfilens namn i parantesen.
    //FindObjectofType<AudioManager>().Play(NAME_OF_THE_CLIP_AS_STRING);
}
