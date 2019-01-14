using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class MiniGameController : MonoBehaviour
{
    private int score = 0;
    public PirateShipController player;
    public GameObject PlayPauseBtn; // 게임 실행/일시정지 버튼 
    public GameObject GameResultUI; // 결과 창
    public GameObject JumpBtn; // 점프 버튼
    public Text velocityLabel;
    public TextMesh scoreHoveringLabel;
    public Text ResultUIscoreLabel;
    public Text ResultUIHighestscoreLabel;
    public Text ResultUIrankingLabel;
    public GameObject ResultUINewRecordLabel;
    public GameObject GameResultPanel;
    Animator animator;

    public static MiniGameController instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        animator = GameResultPanel.GetComponent<Animator>();
        PlayfabStat.instance.GetAccountInfo(); // PlayfabID playerfrebs에 저장
    }

    void Update()
    {
        scoreHoveringLabel.text = "+" + score.ToString(); // 코인 개수 UI 표시

        // 동전이 1개 이상일 경우 점프 버튼 표시
        if (score > 0) JumpBtn.SetActive(true);
        else JumpBtn.SetActive(false);

        // 게임오버 시
        if (player.Life() <= 0)
        {
            GameResultUI.SetActive(true); // 결과창 활성화
            PlayfabStat.instance.SaveStats(score); // Playfab 리더보드 추가, SaveStats()에서 랭킹도 함께 처리

#if UNITY_ANDROID
            ReportScore(score); // PlayFab 리더보드에 추가
            UnlockAchievement(score); // GPGS 업적추가
#endif

            PlayPauseBtn.SetActive(false); // 결과창 활성화 되었을 때 플레이/일시정지 버튼 비활성화

            // 최고기록 달성 시
            if (score >= PlayerPrefs.GetInt("BESTSCORE"))
            {
                PlayerPrefs.SetInt("BESTSCORE", score); // 최고기록 저장
                PlayerPrefs.Save();
                ResultUINewRecordLabel.SetActive(true); // 최고기록 라벨 활성화
            }
            ResultUIHighestscoreLabel.text = "BEST SCORE  " + PlayerPrefs.GetInt("BESTSCORE"); // 최고기록 텍스트 표시
            ResultUIscoreLabel.text = "SCORE  " + score; // 현재기록 텍스트 표시

            AnimateGameResultPanel(); // 결과창 애니메이션 실행
        }
    }

    public void GameResult()
    {
        GameResultUI.SetActive(true); // 결과창 활성화
    }

    // 코인 계산 함수
    public void Score(int score)
    {
        this.score += score; // 코인 수 계산
        if (score == 1) StartCoroutine("HoveringScoreColor_coin");              // 코인 획득 시 코루틴 실행
        else if (score == 10) StartCoroutine("HoveringScoreColor_animals");     // 동물 획득 시 코루틴 실행
        else if (score == -1) StartCoroutine("HoveringScoreColor_jump");        // 점프 시 코루틴 실행

    }

    // 코인 수 반환 함수
    public int getScore()
    {
        return score;
    }

    // 결과 창 애니메이션 실행 함수
    public void AnimateGameResultPanel()
    {
        if (GameResultPanel.activeInHierarchy) animator.SetBool("isOpen", true); // 결과 창이 위쪽에서부터 내려옴
    }

    // 코인 획득 시 UI 상태 코루틴
    IEnumerator HoveringScoreColor_coin()
    {
        MiniGameController.instance.scoreHoveringLabel.color = new Color32(0, 207, 51, 255);        // UI의 색깔이 녹색으로 변경
        yield return new WaitForSeconds(0.2f);
        MiniGameController.instance.scoreHoveringLabel.color = new Color32(255, 255, 255, 255);
    }

    // 동물 획득 시 UI 상태 코루틴
    IEnumerator HoveringScoreColor_animals()
    {
        MiniGameController.instance.scoreHoveringLabel.color = new Color32(25, 0, 255, 255);        // UI의 색깔이 파란색으로 변경
        yield return new WaitForSeconds(0.3f);
        MiniGameController.instance.scoreHoveringLabel.color = new Color32(255, 255, 255, 255);
    }

    // 점프 시 UI 상태 코루틴
    IEnumerator HoveringScoreColor_jump()
    {
        MiniGameController.instance.scoreHoveringLabel.color = new Color32(255, 0, 0, 255);         // UI의 색깔이 빨간색으로 변경
        yield return new WaitForSeconds(0.5f);
        MiniGameController.instance.scoreHoveringLabel.color = new Color32(255, 255, 255, 255);
    }

#if UNITY_ANDROID
    public void ReportScore(int score) // 랭킹 입력
    {
        PlayGamesPlatform.Instance.ReportScore(score, GPGSIds.leaderboard, null);
    }
#endif

#if UNITY_ANDROID
    // GPGS 업적 함수
    public void UnlockAchievement(int score)
    {
        if (score >= 50 && score < 100) PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_50, 100f, null);
        else if (score >= 100 && score < 150) PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_100, 100f, null);
        else if (score >= 150 && score < 200) PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_150, 100f, null);
        else if (score >= 200) PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_200, 100f, null);
    }
#endif
}
