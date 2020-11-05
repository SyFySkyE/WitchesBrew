using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Calculates the tip for each order upon its completion and adds it to the tip total
/// </summary>
public class TipJar : MonoBehaviour
{
    public double Tip { get; set; }

  

    [SerializeField]
    private DialogueManager dialogueManger;

    [SerializeField]
    private Cauldron cauldron;

    [SerializeField]
    private CustomerTimer customerTimer;

    [SerializeField]
    private Slider tipBarSlider;

    [SerializeField]
    [Tooltip("The maximum possible tip a customer can give, must be larger than 0")]
    private double maxPossibleTip = 5;

    [Header("Timer Score Component")]
    [SerializeField]
    [Tooltip("Percentage of 1/3 of order tip based on timer. 0.1 = 10%, 1 = 100%")]
    [Range(0, 1)]
    private double greenTimerPercent = 1;

    [SerializeField]
    [Tooltip("Percentage of 1/3 of order tip based on timer. 0.1 = 10%, 1 = 100%")]
    [Range(0, 1)]
    private double yellowTimerPercent = 0.8;

    [SerializeField]
    [Tooltip("Percentage of 1/3 of order tip based on timer. 0.1 = 10%, 1 = 100%")]
    [Range(0, 1)]
    private double redTimerPercent = 0.5;

    [Header("Conversation Score Component")]
    [SerializeField]
    [Tooltip("Percentage of 1/3 of order tip based on conversation quality. 0.1 = 10%, 1 = 100%")]
    [Range(0, 1)]
    private double positiveResponsePercent = 1;

    [SerializeField]
    [Tooltip("Percentage of 1/3 of order tip based on conversation quality. 0.1 = 10%, 1 = 100%")]
    [Range(0, 1)]
    private double neutralResponsePercent = 0.5;

    [SerializeField]
    [Tooltip("Percentage of 1/3 of order tip based on conversation quality. 0.1 = 10%, 1 = 100%")]
    [Range(0, 1)]
    private double negativeResponsePercent = 0;

    private Order currentOrder;

    private void Start()
    {
        tipBarSlider.maxValue = (float)LevelManager.tipGoal;
    }

    private void OnOrderCompleted(Order currentOrder)
    {
        FindObjectOfType<AudioManager>().Play("DrinkComplete");
        this.currentOrder = currentOrder;
        CalculateTipAndAddItToTotal();
        UpdateTipJarDisplay();
        
    }

    private void CalculateTipAndAddItToTotal()
    {
        double totalOrderQualityPercent = GetTimerPercent() * GetOrderAccuracyPercent() * GetConversationQualityPercent();

        currentOrder.tip = totalOrderQualityPercent * maxPossibleTip;

        LevelManager.totalTips += currentOrder.tip;
    }

    private void UpdateTipJarDisplay()
    {
        tipBarSlider.value = (float)LevelManager.totalTips;
    }

    private double GetConversationQualityPercent()
    {
        double conversationPercent = 0;
         switch (dialogueManger.dialogueValueSelected)
         {
             case DialogueValue.Positive:
                 conversationPercent = positiveResponsePercent;
                 break;
             case DialogueValue.Neutral:
                 conversationPercent = neutralResponsePercent;
                 break;
             case DialogueValue.Negative:
                 conversationPercent = negativeResponsePercent;
                 break;
            default:
                conversationPercent = negativeResponsePercent;
                break;
         }

        Debug.Log("Player scored " + conversationPercent + " on conversation");
        return conversationPercent;

    }

    /// <summary>
    /// Multiplies the base score by a modifier depending on if the timer is in the green, yellow, or red state
    /// </summary>
    /// <returns>Returns a new maximum possible score</returns>
    private double GetTimerPercent()
    {
        double timerPercent = greenTimerPercent;
        switch (customerTimer.CurrentSatisfaction)
        {
            case CustomerHappiness.Green:
                timerPercent = greenTimerPercent;
                break;
            case CustomerHappiness.Yellow:
                timerPercent = yellowTimerPercent;
                break;
            case CustomerHappiness.Red:
                timerPercent = redTimerPercent;
                break;
        }

        return timerPercent;
    }

    private double GetOrderAccuracyPercent()
    {
        List<IngredientEnum> ingredientsInRecipe = currentOrder.recipe.ToList();

        int numberOfCorrectIngredients = 0;
        for (int j = 0; j < cauldron.CurrentIngredients.Count; j++) //for each ingredient in the cauldron
        {
            for (int i = 0; i < ingredientsInRecipe.Count; i++) //check if it's in the recipe
            {
                //vv temp code vv
                if (cauldron.CurrentIngredients[j] == ingredientsInRecipe[i])
                {
                    //add hack to check if cauldron.CurrentIngredients > numberOfCorrectIngredients. If so numberOfCorrectIngredients/cauldron.CurrentIngredients = numberOfCorrectIngredients
                    if (cauldron.CurrentIngredients.Count > currentOrder.recipe.Length)
                    {
                        numberOfCorrectIngredients = numberOfCorrectIngredients / cauldron.CurrentIngredients.Count;
                    }
                    else
                    {
                        numberOfCorrectIngredients++;
                        ingredientsInRecipe.RemoveAt(i);
                    }
                    //^^ temp code ^^
                    //numberOfCorrectIngredients++;
                    //ingredientsInRecipe.RemoveAt(i);
                }
            }
        }

        double accuracyPercent = (double)numberOfCorrectIngredients / currentOrder.recipe.Length;
        Debug.Log($"{currentOrder.name} was {accuracyPercent} accurate");
        return accuracyPercent;
    }

    private void OnEnable()
    {
        OrderManager.OrderCompleted += OnOrderCompleted;
    }

    private void OnDisable()
    {
        OrderManager.OrderCompleted -= OnOrderCompleted;
    }
}
