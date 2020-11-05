﻿using UnityEngine;
using UnityEngine.UI;

public enum CustomerHappiness
{
    Green,
    Yellow,
    Red,
    Fail
}

public class CustomerTimer : MonoBehaviour
{
    [Header("Timer Paramters, in seconds")]
    [SerializeField] private float startTime;
    [SerializeField] private float greenThreshold;
    [SerializeField] private float yellowThreshold;
    [SerializeField] private float redThreshold;
    [SerializeField] private float failThreshold;

    [Header("Bar Fill Area")]
    [SerializeField] private Image fill;
    [SerializeField] private Slider timerSlider;

    public CustomerHappiness CurrentSatisfaction
    {
        get
        {
            return this.currentSatisfaction;
        }
        private set
        {
            if (value != this.currentSatisfaction)
            {
                this.currentSatisfaction = value;
            }
        }
    }

    private CustomerHappiness currentSatisfaction;

    private void Start()
    {
        timerSlider.maxValue = timerSlider.value = startTime;
        CompleteOrderButton.DoneButtonClicked += CompleteOrderButton_DoneButtonClicked;
        FindObjectOfType<AudioManager>().Play("Timer");

    }

    private void CompleteOrderButton_DoneButtonClicked()
    {
        timerSlider.value = startTime;
        FindObjectOfType<AudioManager>().Stop("Timer");
        FindObjectOfType<AudioManager>().Play("TimerRing");
    }
    
    private void Update()
    {
        
        SubtractTime();
    }

    private void SubtractTime()
    {
        
        if (timerSlider.value > failThreshold)
        {
            
            if (timerSlider.value > greenThreshold)
            {
                this.CurrentSatisfaction = CustomerHappiness.Green;
                fill.color = Color.green;
            }
            else if (timerSlider.value > yellowThreshold)
            {
                this.CurrentSatisfaction = CustomerHappiness.Yellow;
                fill.color = Color.yellow;
            }
            else if (timerSlider.value > redThreshold)
            {
                this.CurrentSatisfaction = CustomerHappiness.Red;
                fill.color = Color.red;
            }
            ;
            timerSlider.value -= Time.deltaTime;
            
        }
        else
        {
            this.CurrentSatisfaction = CustomerHappiness.Fail;
            Debug.Log("You lose!");
            
        }
    }
}
