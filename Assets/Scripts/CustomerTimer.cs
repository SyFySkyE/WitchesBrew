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
    public bool Paused
    {
        get { return paused; }
        set
        {
            if (!value) { StartTimer(); } //if timer is being unpaused start the timer
            else { timer.SetActive(false); }
            paused = value;
        }
    }

    private bool paused = true;

    [Header("Timer Paramters, in seconds")]
    [SerializeField] private float startTime;
    [SerializeField] private float greenThreshold;
    [SerializeField] private float yellowThreshold;
    [SerializeField] private float redThreshold;
    [SerializeField] private float failThreshold;

    [Header("Bar Fill Area")]
    [SerializeField] private Image fill;
    [SerializeField] private GameObject timer;

    private Slider timerSlider;

    private void Start()
    {
        timerSlider = timer.GetComponent<Slider>();
    }

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

    public void StartTimer()
    {
        timer.SetActive(true);
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
        if(!Paused)
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
