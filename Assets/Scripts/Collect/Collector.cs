using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public float score = 0f;
    public float pointIncrement = 1f;
    public event Action OnScoreChange;

    public void OnCollect()
    {
        score += pointIncrement;
        OnScoreChange?.Invoke();
    }
}
