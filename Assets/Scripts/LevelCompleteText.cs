using TMPro;
using UnityEngine;

public class LevelCompleteText : MonoBehaviour
{
    private TMP_Text textObj;

    private void Start()
    {
        textObj = GetComponent<TMP_Text>();
    }

    private void OnLevelCompleted()
    {
        if (LevelManager.totalTips >= LevelManager.tipGoal)
        {
            textObj.text = "Level Passed";
        }
        else
        {
            textObj.text = "Level Failed";
        }
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
