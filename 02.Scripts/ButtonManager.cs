using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject SceneTransitionImage;
    public GameObject QuitUI;
    public GameObject SoundOnBtn;
    public GameObject SoundOffBtn;
    public CameraFollow Camera;
    public PirateShipController PirateShip;
    //public Shooter cannonShooter;

    private bool isPause = false; // 일시정지 플래그

    void Start()
    {
        if (PlayerPrefs.GetInt("SoundStatus") == 0) // 소리가 켜진 상태에서는 사운드 ON 버튼 활성화
        {
            SoundOnBtn.SetActive(true);
            SoundOffBtn.SetActive(false);
        }
        else                                        // 소리가 꺼진 상태에서는 사운드 OFF 버튼 활성화
        {
            SoundOnBtn.SetActive(false);
            SoundOffBtn.SetActive(true);
        }
    }

    void Update()
    {
        //일시정지 ON
        if (isPause) Time.timeScale = 0;
        //일시정지 OFF
        else if (!isPause) Time.timeScale = 1;

        // 안드로이드에서 뒤로가기 버튼 눌렀을 시 종료
        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKey(KeyCode.Escape))
            {
                isPause = true; //일시정지 시작
                ActiveQuitUI(); // 종료 창 활성화
            }
    }

    // 버튼 활성화
    public void enableButton(GameObject onButton)
    {
        onButton.SetActive(true);
    }

    // 버튼 비활성화
    public void disableButton(GameObject offButton)
    {
        offButton.SetActive(false);
    }

    // 일시정지 버튼 눌렀을 때
    public void ClickPauseBtn()
    {
        isPause = true; //일시정지 시작
    }

    // 재생 버튼 눌렀을 때
    public void ClickPlayBtn() 
    {
        isPause = false; //일시정지 종료
    }

    // 타이틀 화면으로 돌아갈 때
    public void ReturnToTitle() 
    {
        SceneTransitionImage.SetActive(true); // 화면 전환 애니매이션 활성화
        //SceneManager.LoadScene(0); // 처음으로 돌아가기
    }

    // 카메라가 완전히 회전한 다음에 시작 버튼이 비활성화
    public void disableStartBtn(GameObject offButton)
    {
        if (Camera.CameraReady())
        {
            offButton.SetActive(false);
            PirateShip.start(); // 배출발
        }
    }

    // 종료창 활성화
    public void ActiveQuitUI()
    {
        QuitUI.SetActive(true);
    }

    // 게임 종료
    public void QuitGame()
    {
        Application.Quit();
    }

    // 클릭음 재생
    public void PlayClickSound()
    {
        SoundManager.instance.PlayClickSound(); // 클릭 사운드 재생
    }

    // 사운드 On 함수
    public void OnAllSound()
    {
        SoundManager.instance.OnAllSound(); // 모든 사운드 ON
        PlayerPrefs.SetInt("SoundStatus", 0); // 사운드 설정 버튼 상태 기억(켜진상태:0)
    }

    // 사운드 Off 함수
    public void OffAllSound()
    {
        SoundManager.instance.OffAllSound(); // 모든 사운드 OFF
        PlayerPrefs.SetInt("SoundStatus", 1); // 사운드 설정 버튼 상태 기억(꺼진상태:1)
    }

    //public void CannonBtn()
    //{
    //    cannonShooter.Active_CannonBall();
    //}

}
