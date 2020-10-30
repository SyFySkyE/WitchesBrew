using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterActionUI : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    private void OnLevelCompleted()
    {
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    private void OnEnable()
    {
        OrderManager.LevelCompleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        OrderManager.LevelCompleted -= OnLevelCompleted;
    }

    #region BUTTONS
    public void OnRestartLevelClicked()
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void OnNextLevelClicked()
    {

    }

    public void OnMainMenuClicked()
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        SceneManager.LoadScene("MainMenu");
    }

    #endregion
}
