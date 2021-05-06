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

    public AudioMixer SFXMixer;


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

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.output;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }

    private void Start()
    {
        SFXMixer.SetFloat("GrindVolume", -80f);
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
                    //SetFadeIO();
                }

            }
            catch(NullReferenceException e)
            {
                Debug.LogWarning("Point Counter has not been assigned to an object");
            }
        }
    }

    /*
    private void SetFadeIO()
    {
        switch (mode)
        {
            case 1:
                //Sätt rätt fil i rätt mode
                print("Fading out...");
                StartCoroutine(FadeOut("MenuTheme"));
                break;
            case 2:
                print("Fading in...");
                StartCoroutine(FadeIn("MenuTheme"));
                break;
            case 3:
                print("Fading out...");
                StartCoroutine(FadeOut("MenuTheme"));
                break;
            case 4:
                print("Fading in...");
                StartCoroutine(FadeIn("MenuTheme"));
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

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Ljudfilen hittades inte!");
            return;
        }
        s.source.Stop();
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

    public void MuteMusic()
    {
        foreach(Sound s in sounds)
        {
            if(s.name == "MenuTheme" || s.name == "GameTheme")
            {
                s.source.mute = true;
            }
        }
    }

    public void UnmuteMusic()
    {
        foreach (Sound s in sounds)
        {
            if (s.name == "MenuTheme" || s.name == "GameTheme" && s.source.mute == true)
            {
                s.source.mute = false;
            }
        }
    }


    public void MuteSFX()
    {
        foreach(Sound s in sounds)
        {
            if(s.source.outputAudioMixerGroup.audioMixer.name == "SFX")
            {
                s.source.mute = true;
            }
        }
    }

    public void UnmuteSFX()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.outputAudioMixerGroup.audioMixer.name == "SFX" && s.source.mute == true)
            {
                s.source.mute = false;
            }
        }
    }

    public List<Sound> GetToggledClips()
    {
        return toggledClips;
    }

    /*
    public IEnumerator FadeIn(string str)
    {
        Sound s = GetAudioclip(str);

        s.musicAnimator = anim;
        anim.runtimeAnimatorController = universalFade;
        s.musicAnimator.SetTrigger("FadeIn");
        s.musicAnimator = null;
        yield return new WaitForSeconds(fadeWaitForSecs);
    }

    public IEnumerator FadeOut(string str)
    {
        Sound s = GetAudioclip(str);

        
        if (!str.Equals(s.name))
        {
            Debug.LogWarning("Fade out name doesn't match");
        }
        

        s.musicAnimator = anim;
        anim.runtimeAnimatorController = universalFade;
        
        foreach(AnimationClip a in anim.runtimeAnimatorController.animationClips)
        {
            if (a.name.Equals("FadeOut"))
            {
                //a.
            }
        }

        //s.musicAnimator.Set
        s.musicAnimator.SetTrigger("FadeOut");
        //s.musicAnimator = null;
        yield return new WaitForSeconds(fadeWaitForSecs);
    }*/

    //Kod att sätta in för att initiera ett önskat ljud. Man måste sätta in ljudfilens namn i parantesen.
    //FindObjectOfType<AudioManager>().Play(NAME_OF_THE_CLIP_AS_STRING);
}
