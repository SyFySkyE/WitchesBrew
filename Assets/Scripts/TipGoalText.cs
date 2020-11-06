using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TipGoalText : MonoBehaviour
{
    public static event Action LevelStarted;

    [SerializeField]
    private bool fadeTextInAndOut;

    [SerializeField]
    private float fadeInTime, fadeOutTime = 1f;

    [SerializeField]
    private float delayBeforeFadeOutTime = 2f;

    private TextMeshProUGUI goalText;

    private void Start()
    {
        goalText = GetComponent<TextMeshProUGUI>();

        if (fadeTextInAndOut)
        {
            goalText.text = "Today's tip goal: $" + Math.Round(LevelManager.tipGoal, 2).ToString();
            StartCoroutine(FadeTextInAndOut());
        }
        else
        {
            goalText.text = "Out of $" + Math.Round(LevelManager.tipGoal, 2).ToString();
        }
    }

    private IEnumerator FadeTextInAndOut()
    {
        StartCoroutine(FadeTextToFullAlpha(fadeInTime, goalText));
        yield return new WaitForSeconds(delayBeforeFadeOutTime);
        StartCoroutine(FadeTextToZeroAlpha(fadeOutTime, goalText));
    }

    private IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    private IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }

        LevelStarted?.Invoke();
    }

}

