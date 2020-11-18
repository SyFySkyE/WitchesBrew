using System;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
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
        tipText.text = "$" + String.Format("{0:0.00}", Math.Round(LevelManager.totalTips, 2));
    }
}
