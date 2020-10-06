using UnityEngine;

public class LevelManager : MonoBehaviour
{ 
    [HideInInspector]
    public static int totalScore = 0;

    private static int currentLevel = 1;

    private void Start()
    {
        //to do: singleton?
    }
}
