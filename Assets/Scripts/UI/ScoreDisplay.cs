using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public float Result
    {
        get
        {
            return homeScore - awayScore;
        }
    }

    public Text resultText;

    public float homeScore = 0;
    public float awayScore = 0;
    public List<Collector> homeTeam = new List<Collector>();
    public List<Collector> awayTeam = new List<Collector>();

    public void Start()
    {
        homeTeam?.ForEach(i => i.OnScoreChange += UpdateScoreDisplay);
        awayTeam?.ForEach(i => i.OnScoreChange += UpdateScoreDisplay);
    }

    public void UpdateScoreDisplay()
    {
        if (homeTeam.Count > 0)
        {
            homeScore = homeTeam.Sum(i => i.score);
        }

        if (awayTeam.Count > 0)
        {
            awayScore = awayTeam.Sum(i => i.score);
        }

        resultText.text = Result.ToString();
    }
}
