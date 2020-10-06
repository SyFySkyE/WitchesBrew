using System;
using UnityEngine;

public class CompleteOrderButton : MonoBehaviour
{
    public static event Action DoneButtonClicked;

    public void OnButtonClicked()
    {
        DoneButtonClicked?.Invoke();
    }
}
