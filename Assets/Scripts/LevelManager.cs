using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    OrderManager orderManager;

    public static double TotalTips 
    {
        get
        {
            Debug.Log("Accessed total tips value = " + totalTips);
            return totalTips;
        }
        set
        {
            totalTips = value;
            Debug.Log("Changed total tips, new value = " + totalTips);
        }
    }

    private static double totalTips = 0;

    [Tooltip("The tip goal or quota that must be reached to successfully complete a level")]
    public static double tipGoal = 5;

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
