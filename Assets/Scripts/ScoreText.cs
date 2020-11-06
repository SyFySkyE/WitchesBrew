using System;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI tipText;

    private void Start()
    {
        tipText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        tipText.text = "$" + Math.Round(LevelManager.totalTips, 2).ToString();
    }
}
