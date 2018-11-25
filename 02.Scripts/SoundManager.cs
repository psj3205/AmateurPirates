using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip CoinSound;
    public AudioClip MoveSound;
    public AudioClip GameoverSound;
    public AudioClip ClickSound;
    public AudioClip BGMSound;
    //AudioSource AudioSource;
    public static SoundManager instance;

    private AudioSource[] audioSources = new AudioSource[2];
    //private AudioClip[] audioClips = new AudioClip[2];

    void Awake()
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
        for (int i = 0; i < 2; i++)
        {
            audioSources = GetComponents<AudioSource>();
        }

        audioSources[0].clip = BGMSound;
        audioSources[0].loop = true;
        audioSources[0].playOnAwake = true;
        audioSources[0].Play();

        audioSources[1].loop = false;
        audioSources[1].playOnAwake = false;
    }

    // Use this for initialization
    //void Start () {
    //       AudioSource = GetComponent<AudioSource>();
    //   }

    public void PlayCoinSound()
    {
        audioSources[1].PlayOneShot(CoinSound);
    }

    public void PlayMoveSound()
    {
        audioSources[1].PlayOneShot(MoveSound);
    }

    public void PlayGameoverSound()
    {
        audioSources[1].PlayOneShot(GameoverSound);
    }

    public void PlayClickSound()
    {
        audioSources[1].PlayOneShot(ClickSound);
    }

    public void OffAllSound()
    {
        //this.AudioSource.volume = 0;
        this.audioSources[0].volume = 0;
        this.audioSources[1].volume = 0;
    }

    public void OnAllSound()
    {
        //this.AudioSource.volume = 0.8f;
        this.audioSources[0].volume = 0.8f;
        this.audioSources[1].volume = 0.8f;
    }
}
