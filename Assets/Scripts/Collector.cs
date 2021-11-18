using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public void OnCollect()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
