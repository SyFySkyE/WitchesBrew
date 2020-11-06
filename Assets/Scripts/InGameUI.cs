using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
    }

    private void OnLevelCompleted()
    {
        canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        OrderManager.LevelCompleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        OrderManager.LevelCompleted -= OnLevelCompleted;
    }
}
