using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuFunctions : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
