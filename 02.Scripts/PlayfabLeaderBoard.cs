using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayfabLeaderBoard : MonoBehaviour
{
    public GameObject ScoreRecordPrefab;
    public Image image;
    public List<PlayfabScoreRecord> ScoreRecords = new List<PlayfabScoreRecord>();
    private Transform UIParent;

    // 리더보드 호출 함수
    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest();
        request.StartPosition = 0;          // 시작 포지션
        request.MaxResultsCount = 100;      // 총 조회 계정 수
        request.StatisticName = "score";    // 리더보드 이름
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardSuccess, OnPlayFabError);
    }

    // 리더보드 호출 에러 콜백
    private void OnPlayFabError(PlayFabError obj)
    {
        print("Something went wrong");
    }

    // 리더보드 호출 성공 콜백
    private void OnLeaderboardSuccess(GetLeaderboardResult obj)
    {
        UIParent = GameObject.FindGameObjectWithTag("leaderboardcontent").transform; // 리더보드 배치시킬 위치 지정
        PlayfabScoreRecord temp; // temp variable for a scoreRecord
        for (int i = 0; i < obj.Leaderboard.Count; i++)
        {
            // 리더보드 동적 생성
            temp = Instantiate(ScoreRecordPrefab, transform.position, transform.rotation, UIParent).GetComponent<PlayfabScoreRecord>();
            // 호출한 리더보드 값 입력
            temp.WriteRecord((obj.Leaderboard[i].Position + 1).ToString() ,obj.Leaderboard[i].PlayFabId, obj.Leaderboard[i].StatValue.ToString());
            // 로그인 된 계정과 동일한 계정 발견 시
            if (obj.Leaderboard[i].PlayFabId == PlayerPrefs.GetString("PlayfabID"))
            {
                image = temp.GetComponent<Image>();
                image.color = new Color32(64, 139, 255, 90);  // 색상 파란색으로 변경하여 표시
            }
            ScoreRecords.Add(temp);
        }
    }

    // 동적 생성된 랭킹 리스트 반환
    public void DestroyList()
    {
        int childs = UIParent.childCount;
        for (int i = 0; i < childs; i++)
        {
            GameObject.Destroy(UIParent.GetChild(i).gameObject);
        }
    }
}
