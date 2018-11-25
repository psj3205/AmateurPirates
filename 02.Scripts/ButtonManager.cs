using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    //public GameObject StartBtn;
    //public GameObject SettingBtn;
    //public GameObject StartMSG;
    public GameObject SceneTransitionImage;

    //GameObject SettingMenu; // 세팅 메뉴  불러오기 - 이메뉴는 처음에는 비활성화
    private bool isPause = false;
    //private bool MenuOpen = false;

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
        {
            if (Input.GetKey(KeyCode.Escape))

            {
                Application.Quit();
            }
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
