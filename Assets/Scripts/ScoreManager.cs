using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    [HideInInspector]
    public int tips;

    [HideInInspector]
    public int totalScore;

    private void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + totalScore.ToString();
    }

    void AddTipsToScore()
    {

    }

}
