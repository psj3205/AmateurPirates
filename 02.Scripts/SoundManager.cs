using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip CoinSound;         // 코인 효과음
    public AudioClip AnimalSound;       // 동물 효과음
    public AudioClip MoveSound;         // 이동 효과음
    public AudioClip GameoverSound;     // 게임오버 효과음
    public AudioClip ClickSound;        // 클릭 효과음
    public AudioClip JumpSound;         // 점프 효과음
    public AudioClip BGMSound;          // 배경음악

    public static SoundManager instance;
    private AudioSource[] audioSources = new AudioSource[2];

    void Awake()
    {
        // SoundManager 객체가 생성되어 있지 않다면
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this; // 객체 생성
            for (int i = 0; i < 2; i++)
            {
                audioSources = GetComponents<AudioSource>();
            }

            // audioSources[0]에 배경음악 입력
            audioSources[0].clip = BGMSound;
            audioSources[0].loop = true;            // 반복재생
            audioSources[0].playOnAwake = true;     // 객체 생성과 동시에 자동 재생
            audioSources[0].Play();

            if (PlayerPrefs.GetInt("SoundStatus") == 1) // 이 조건문으로 씬이 다시 로드되었을 때 사운드가 OFF 상태였다면 볼륨을 0으로 만든다
                OffAllSound();

            // 배경음악 이외의 기타 음향
            audioSources[1].loop = false; ;
            audioSources[1].playOnAwake = false;

            // 씬이 다시 로드되어도 이 객체가 파괴되지 않게 한다. 설정을 게임이 실행되는 동안 유지하기 위해서
            DontDestroyOnLoad(this.gameObject);
        }

        // 이미 객체가 있다면 더 이상 SouondManager객체를 생성하지 않는다
        else
            Destroy(this.gameObject);
    }

    // 코인 효과음 함수
    public void PlayCoinSound()
    {
        audioSources[1].PlayOneShot(CoinSound);
    }

    // 동물 효과음 함수
    public void PlayAnimalSound()
    {
        audioSources[1].PlayOneShot(AnimalSound);
    }

    // 이동 효과음 함수
    public void PlayMoveSound()
    {
        audioSources[1].PlayOneShot(MoveSound);
    }

    // 점프 효과음 함수
    public void PlayJumpSound()
    {
        audioSources[1].PlayOneShot(JumpSound);
    }

    // 게임호버 효과음 함수
    public void PlayGameoverSound()
    {
        audioSources[1].PlayOneShot(GameoverSound);
    }

    // 클릭 효과음 함수
    public void PlayClickSound()
    {
        audioSources[1].PlayOneShot(ClickSound);
    }

    // 모든 사운드 off 함수
    public void OffAllSound()
    {
        //this.AudioSource.volume = 0;
        this.audioSources[0].volume = 0;
        this.audioSources[1].volume = 0;
    }

    // 모든 사운드 on 함수
    public void OnAllSound()
    {  
        //this.AudioSource.volume = 0.8f;
        this.audioSources[0].volume = 0.8f;
        this.audioSources[1].volume = 0.8f;
    }
}
