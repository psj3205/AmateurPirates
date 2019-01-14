using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayfabScoreRecord : MonoBehaviour {
    public Text Ranking;
    public Text Name;
    public Text Score;

    private void OnEnable()
    {
        var textFields = GetComponentsInChildren<Text>();
        Ranking = textFields.First(f => f.name == "ranking");
        Name = textFields.First(f => f.name == "name");
        Score = textFields.First(f => f.name == "score");
    }

    public void WriteRecord(string ranking, string name, string score)
    {
        Ranking.text = ranking;
        Name.text = name;
        Score.text = score;
    }
}
