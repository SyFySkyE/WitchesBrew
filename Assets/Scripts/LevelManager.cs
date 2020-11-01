using UnityEngine;

public class LevelManager : MonoBehaviour
{ 
    [HideInInspector]
    public static double totalTips = 0;

    [Tooltip("The tip goal or quota that must be reached to successfully complete a level")]
    public static double tipGoal = 5;

    private static int currentLevel = 1;

    private void Start()
    {
        //to do: singleton?
    }
}
