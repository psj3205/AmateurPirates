using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabStat : MonoBehaviour
{
    public static PlayfabStat instance;

    void Awake()
    {
        instance = this;
    }

    // 점수 업데이트 함수
    public void SaveStats(int score)
    {
        // 새로운 request 생성
        var request = new UpdatePlayerStatisticsRequest();
        // statistics 리스트 생성
        request.Statistics = new List<StatisticUpdate>();
        // 점수 입력
        var stat = new StatisticUpdate { StatisticName = "score", Value = score };
        // request에 추가
        request.Statistics.Add(stat);
        // PlayFab API 호출
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSetStatsSuccess, OnPlayFabError);

    }

    // 점수 업데이트 함수 호출 에러 콜백
    private void OnPlayFabError(PlayFabError obj)
    {
        //print(" Something went wrong in the stats script ");
    }

    // 점수 업데이트 함수 호출 성공 콜백
    private void OnSetStatsSuccess(UpdatePlayerStatisticsResult obj)
    {
        // print(" New statistics saved ");
        // 랭킹 함수 실행
        GetMyRanking();
    }

    public void GetStats()
    {
        // Create a new request
        var request = new GetPlayerStatisticsRequest();
        request.StatisticNames = new List<string>() { "score" };
        // Passing to PlayFab API
        PlayFabClientAPI.GetPlayerStatistics(request, GetStatsSuccess, OnPlayFabError);
    }

    private void GetStatsSuccess(GetPlayerStatisticsResult obj)
    {
        //print(" Stats received successfully ");

        // output statistics
        foreach (var stat in obj.Statistics)
        {
            print(" Statistic: " + stat.StatisticName + " value: " + stat.Value);
        }
    }

    public void GetAccountInfo()
    {
        GetAccountInfoRequest request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoSuccess, OnPlayFabError);
    }

    private void OnGetAccountInfoSuccess(GetAccountInfoResult result)
    {
        PlayerPrefs.SetString("PlayfabID", result.AccountInfo.PlayFabId); // PlayfabID 를 PlayerPrefs에 저장
    }

    // 나의 순위 호출 함수
    public void GetMyRanking()
    {
        GetLeaderboardAroundPlayerRequest request = new GetLeaderboardAroundPlayerRequest();
        request.MaxResultsCount = 1;
        request.StatisticName = "score";
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, GetMyRankingSuccess, OnPlayFabError);
    }

    // 나의 순위 호출 함수 성공 콜백
    private void GetMyRankingSuccess(GetLeaderboardAroundPlayerResult result)
    {
        // Ranking을 표시
        MiniGameController.instance.ResultUIrankingLabel.text = "Ranking " + (result.Leaderboard[0].Position + 1).ToString();
    }
}
