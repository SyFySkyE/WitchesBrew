using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    OrderManager orderManager;

    [HideInInspector]
    public static double totalTips = 0;

    private static int currentLevel = 1;

    void OnLevelStarted()
    {
        orderManager.Paused = false;
    }

    private void OnEnable()
    {
        TipGoalText.LevelStarted += OnLevelStarted;
    }

    private void OnDisable()
    {
        TipGoalText.LevelStarted -= OnLevelStarted;
    }
}
