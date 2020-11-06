using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public bool check = true;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (check == false))
        {                       
           OpenPauseMenu();
           Debug.Log("tick on ");
        }
        else if ((Input.GetKeyDown(KeyCode.Escape)) && (check == true))
        {
            ClosePauseMenu();
            Debug.Log("tick off");
        }
    }

    private void OpenPauseMenu()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        check = true;
    }

    private void ClosePauseMenu()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        check = false;

    }
}
