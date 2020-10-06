using UnityEngine;

public class AfterActionUI : MonoBehaviour
{
    [SerializeField]
    GameObject inGameUI;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnLevelCompleted()
    {
        gameObject.SetActive(true);
        inGameUI.SetActive(false);
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
