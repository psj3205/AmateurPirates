using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPGSManager : MonoBehaviour {

    public Text stateText;
    private Action<bool> signInCallback;

#if !UNITY_EDITOR && UNITY_ANDROID
    void Awake()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);

        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Activate();

        signInCallback = (bool success) =>
        {
            if (success)
                stateText.text = "로그인 성공!";
            else
                stateText.text = "로그인 실패!";
        };
    }

    void Start()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
            PlayGamesPlatform.Instance.Authenticate(signInCallback);
    }
#endif
    //public void SignIn()
    //{
    //    if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
    //        PlayGamesPlatform.Instance.Authenticate(signInCallback);
    //}
    //public void SignOut()
    //{
    //    if(PlayGamesPlatform.Instance.IsAuthenticated() == true)
    //    {
    //        stateText.text = "Bye~~!";
    //        PlayGamesPlatform.Instance.SignOut();
    //    }
    //}

    public void ShowLeaderboardUI()
    {
        signInCallback = (bool success) =>
        {
            if (success)
                stateText.text = "로그인 성공!";
            else
                stateText.text = "로그인 실패!";
        };
#if !UNITY_EDITOR && UNITY_ANDROID
        // 로그인 되지 않은 상태에서 리더보드 클릭 시 로그인 절차 진행
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
            PlayGamesPlatform.Instance.Authenticate(signInCallback);

        // 리더보드창 실행
        PlayGamesPlatform.Instance.ShowLeaderboardUI();
#endif
    }

    public void ShowAchievementUI()
    {
        signInCallback = (bool success) =>
        {
            if (success)
                stateText.text = "로그인 성공!";
            else
                stateText.text = "로그인 실패!";
        };
#if !UNITY_EDITOR && UNITY_ANDROID

        // 로그인 되지 않은 상태에서 업적 클릭 시 로그인 절차 진행
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
            PlayGamesPlatform.Instance.Authenticate(signInCallback);

        // 업적창 실행
        PlayGamesPlatform.Instance.ShowAchievementsUI();
#endif
    }
}