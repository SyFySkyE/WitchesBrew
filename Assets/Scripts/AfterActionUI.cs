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
        canvasGroup.alpha = 1;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void OnNextLevelClicked()
    {

    }

    public void OnMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    #endregion
}
