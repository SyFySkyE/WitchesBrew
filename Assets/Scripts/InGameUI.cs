using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnLevelCompleted()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    void OnLevelStarted()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }

    private void OnEnable()
    {
        OrderManager.LevelCompleted += OnLevelCompleted;
        TipGoalText.LevelStarted += OnLevelStarted;
    }

    private void OnDisable()
    {
        OrderManager.LevelCompleted -= OnLevelCompleted;
        TipGoalText.LevelStarted -= OnLevelStarted;
    }
}
