using UnityEngine;

public class LevelManager : MonoBehaviour
{ 
    [HideInInspector]
    public static double totalTips = 0;

    private static int currentLevel = 1;

    private void Start()
    {
        //to do: singleton?
    }
}
