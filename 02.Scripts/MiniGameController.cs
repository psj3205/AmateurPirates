using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class MiniGameController : MonoBehaviour
{
    //public int coin = 0;
    public int score = 0;
    public PirateShipController player;
    public GameObject PlayPauseBtn; // 게임 실행/일시정지 버튼 
    public GameObject GameResultUI; // 결과 창
    //public Text coinLabel;
    public Text scoreLabel;
    public Text ResultUIscoreLabel;
    public Text ResultUIHighestscoreLabel;
    public GameObject ResultUINewRecordLabel;
    public GameObject GameResultPanel;
    Animator animator;
    //public Text stateLabel;

    void Start()
    {
        animator = GameResultPanel.GetComponent<Animator>();
        
    }

    void Update()
    {
        //coinLabel.text = "COIN " + coin;

        //if ((int)player.transform.position.x >= 0)
        //    score = (int)player.transform.position.x;
        scoreLabel.text = score.ToString();


        if (player.Life() <= 0)
        {
            GameResultUI.SetActive(true); // 결과창 활성화
#if UNITY_ANDROID
            ReportScore(score); // 리더보드에 추가
            UnlockAchievement(score); // 업적추가
#endif
            PlayPauseBtn.SetActive(false); // 결과창 활성화 되었을 때 플레이/일시정지 버튼 비활성화

            if (score >= PlayerPrefs.GetInt("BESTSCORE"))
            {
                PlayerPrefs.SetInt("BESTSCORE", score);
                PlayerPrefs.Save();
                ResultUINewRecordLabel.SetActive(true);
      
            }
            ResultUIHighestscoreLabel.text = "BEST SCORE  " + PlayerPrefs.GetInt("BESTSCORE");
            ResultUIscoreLabel.text = "SCORE  " + score;

            AnimateGameResultPanel();
            //Invoke("ReturnToTitle", 1.0f);
        }
 

        //if (Input.GetMouseButtonDown(0) && state == State.Play)
        //    Score();


    }
    //void ReturnToTitle()
    //{
    //    SceneManager.LoadScene(0);
    //}

    public void AnimateGameResultPanel()
    {
        if (GameResultPanel.activeInHierarchy)
        {
            animator.SetBool("isOpen", true);
        }
    }

#if UNITY_ANDROID
    public void ReportScore(int score) // 랭킹 입력
    {


        PlayGamesPlatform.Instance.ReportScore(score, GPGSIds.leaderboard_ranking, null);
    }
#endif

#if UNITY_ANDROID
    public void UnlockAchievement(int score)
    {
        if (score >= 50 && score < 100)
        {

            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_50, 100f, null);

        }
        else if(score >= 100 && score < 150)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_100, 100f, null);
        }
        else if (score >= 150 && score < 200)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_150, 100f, null);
        }
        else if (score >= 200)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_150, 100f, null);
        }

    }
#endif
}
