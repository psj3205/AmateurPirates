using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    //public GameObject StartBtn;
    //public GameObject SettingBtn;
    //public GameObject StartMSG;
    public GameObject SceneTransitionImage;
    public GameObject QuitUI;
    public GameObject SoundOnBtn;
    public GameObject SoundOffBtn;
    public CameraFollow Camera;
    public PirateShipController PirateShip;

    //GameObject SettingMenu; // 세팅 메뉴  불러오기 - 이메뉴는 처음에는 비활성화
    private bool isPause = false;
    //private bool MenuOpen = false;

    void Start()
    {
        if (PlayerPrefs.GetInt("SoundStatus") == 0) // 소리가 켜진 상태에서는 사운드 ON 버튼 활성화
        {
            SoundOnBtn.SetActive(true);
            SoundOffBtn.SetActive(false);
        }
        else                                       // 소리가 꺼진 상태에서는 사운드 OFF 버튼 활성화
        {
            SoundOnBtn.SetActive(false);
            SoundOffBtn.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause) //일시정지 ON
        {
            Time.timeScale = 0;
        }
        else if(!isPause) //일시정지 OFF
        {
            Time.timeScale = 1;
        }

        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKey(KeyCode.Escape))
            {
                isPause = true; //일시정지 시작
                ActiveQuitUI();
            }

        //if (MenuOpen) //메뉴창 ON
        //{
        //    SettingMenu.SetActive(enabled);//GUI 창 실행
        //}
        //else
        //{
        //    SettingMenu.SetActive(false);//GUI 창 종료
        //}
    }

    public void enableButton(GameObject onButton)
    {
        onButton.SetActive(true);
    }

    // function to disable
    public void disableButton(GameObject offButton)
    {
        offButton.SetActive(false);
    }

    public void ClickPauseBtn() // 톱니바퀴 버튼 눌렀을때
    {
        isPause = true; //일시정지 시작
    }

    public void ClickPlayBtn()
    {
        isPause = false; //일시정지 종료
    }

    public void ReturnToTitle()
    {
        SceneTransitionImage.SetActive(true);
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

    public void ActiveQuitUI()
    {
        QuitUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayClickSound()
    {
        SoundManager.instance.PlayClickSound(); // 클릭 사운드 재생
    }

    public void OnAllSound()
    {
        SoundManager.instance.OnAllSound(); // 모든 사운드 ON
        PlayerPrefs.SetInt("SoundStatus", 0); // 사운드 설정 버튼 상태 기억(켜진상태:0)
    }

    public void OffAllSound()
    {
        SoundManager.instance.OffAllSound(); // 모든 사운드 OFF
        PlayerPrefs.SetInt("SoundStatus", 1); // 사운드 설정 버튼 상태 기억(꺼진상태:1)
    }

    //public void ClickMenuButton() //메인메뉴로 돌아가는 버튼
    //{
    //    MenuOpen = false;
    //    SceneManager.LoadScene("Title");
    //    isPause = true;

    //}

    //public void ClickGoButton() //취소하고 게임을 진행할시
    //{
    //    MenuOpen = false;
    //    StartCoroutine(WaitForIt());
    //    isPause = true;


    //}

    //IEnumerator WaitForIt()
    //{
    //    yield return new WaitForSeconds(1.0f);

    //}
}
