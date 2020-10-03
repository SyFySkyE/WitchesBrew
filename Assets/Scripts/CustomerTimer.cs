using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private Slider timerSlider;

    // Start is called before the first frame update
    void Start()
    {
        timerSlider = GetComponentInChildren<Slider>();
        timerSlider.maxValue = timerSlider.value = startTime;        
    }

    // Update is called once per frame
    void Update()
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
            }
            else if (timerSlider.value > yellowThreshold)
            {
                this.CurrentSatisfaction = CustomerHappiness.Yellow;
            }
            else if (timerSlider.value > redThreshold)
            {
                this.CurrentSatisfaction = CustomerHappiness.Red;
            }

            timerSlider.value -= Time.deltaTime;
        }
        else
        {
            this.CurrentSatisfaction = CustomerHappiness.Fail;
            Debug.Log("You lose!");
        }       
    }
}
