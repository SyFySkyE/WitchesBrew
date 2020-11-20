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

    private void OnOrderCompleted(Order o)
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        tipText.text = "$" + String.Format("{0:0.00}", Math.Round(LevelManager.TotalTips, 2));
    }

    private void OnEnable()
    {
        OrderManager.OrderCompleted += OnOrderCompleted;
    }

    private void OnDisable()
    {
        OrderManager.OrderCompleted -= OnOrderCompleted;
    }
}
