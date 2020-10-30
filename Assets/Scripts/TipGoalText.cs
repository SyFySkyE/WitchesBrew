using System;
using TMPro;
using UnityEngine;

public class TipGoalText : MonoBehaviour
{
    [SerializeField]
    private TipJar tipJar;

    private TextMeshProUGUI goalText;

    private void Start()
    {
        goalText = GetComponent<TextMeshProUGUI>();
        goalText.text = "Out of: $" + Math.Round(tipJar.tipGoal, 2).ToString();
    }
}
