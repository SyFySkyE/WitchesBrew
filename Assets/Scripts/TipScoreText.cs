using System;
using TMPro;
using UnityEngine;

public class TipScoreText : MonoBehaviour
{
    private TMP_Text tipText;

    private void Start()
    {
        tipText = GetComponent<TMP_Text>();
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
