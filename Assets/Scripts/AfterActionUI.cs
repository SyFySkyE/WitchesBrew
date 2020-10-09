using UnityEngine;

public class AfterActionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameUI;
    private CanvasGroup canvasGroup, inGameCanvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        inGameCanvasGroup = inGameUI.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    private void OnLevelCompleted()
    {
        canvasGroup.alpha = 1;
        inGameCanvasGroup.alpha = 0;
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
