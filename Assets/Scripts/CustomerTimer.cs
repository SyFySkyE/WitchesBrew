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

    [Header("Bar Fill Area")]
    [SerializeField] private Image fill;
    [SerializeField] private Slider timerSlider;

    [SerializeField] private AudioClip timer;
    [SerializeField] private AudioClip timerRing;
    public AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
        timerSlider.maxValue = timerSlider.value = startTime;
        CompleteOrderButton.DoneButtonClicked += CompleteOrderButton_DoneButtonClicked;

    }

    private void CompleteOrderButton_DoneButtonClicked()
    {
        timerSlider.value = startTime;
    }

    private void Update()
    {
        
        SubtractTime();
    }

    private void SubtractTime()
    {
        if (timerSlider.value > failThreshold)
        {
            //audioSource.PlayOneShot(timer);
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
            //audioSource.Stop();
            //audioSource.loop = false;
            //audioSource.PlayOneShot(timerRing);
        }
    }
}
