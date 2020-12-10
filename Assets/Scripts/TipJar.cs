using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Calculates the tip for each order upon its completion and adds it to the tip total
/// </summary>
public class TipJar : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dialogueManger;

    [SerializeField]
    private Cauldron cauldron;

    [SerializeField]
    private CustomerTimer customerTimer;

    [SerializeField]
    private Transform tipFillTransform;

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
    private double neutralResponsePercent = 0.7;

    [SerializeField]
    [Tooltip("Percentage of 1/3 of order tip based on conversation quality. 0.1 = 10%, 1 = 100%")]
    [Range(0, 1)]
    private double negativeResponsePercent = 0.5;

    private Order currentOrder;
    private float tipMax;

    private void Start()
    {
        tipMax = (float)LevelManager.tipGoal;
        LevelManager.TotalTips = 0;
        UpdateTipJarDisplay();
    }

    private void OnOrderCompleted(Order currentOrder)
    {
        FindObjectOfType<AudioManager>().Play("DrinkComplete");
        this.currentOrder = currentOrder;
        CalculateTipAndAddItToTotal();
        
        if(LevelManager.TotalTips < LevelManager.tipGoal)
        {
            FindObjectOfType<AudioManager>().Play("TipReceived");
            UpdateTipJarDisplay();
        }
            
    }

    private void CalculateTipAndAddItToTotal()
    {
        double totalOrderQualityPercent = GetTimerPercent() * GetOrderAccuracyPercent() * GetConversationQualityPercent();

        
        currentOrder.tip = Math.Round((totalOrderQualityPercent * maxPossibleTip), 2);

        LevelManager.TotalTips += currentOrder.tip;
        Debug.Log("currentOrder.tip is " + currentOrder.tip);
        cauldron.ClearIngredients();
    }

    private void UpdateTipJarDisplay()
    {
        
        float yScale = (float)LevelManager.TotalTips / tipMax;
        tipFillTransform.localScale = new Vector3(tipFillTransform.localScale.x, yScale,tipFillTransform.localScale.z);
    }

    private double GetConversationQualityPercent()
    {
        double conversationPercent = negativeResponsePercent;
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
        Debug.Log("Timer percent is " + timerPercent);

        return timerPercent;
    }

    private double GetOrderAccuracyPercent()
    {
        List<IngredientEnum> ingredientsInRecipe = new List<IngredientEnum>(currentOrder.recipe);

        Debug.Log("Printing recipe ingredients");
        foreach (IngredientEnum recipeItem in ingredientsInRecipe)
            Debug.Log("Recipe item " + recipeItem);

        int numberOfCorrectIngredients = 0;

         Debug.Log("cauldron.CurrentIngredients.Count: " + cauldron.CurrentIngredients.Count);
        for (int j = 0; j < cauldron.CurrentIngredients.Count; j++) //for each ingredient in the cauldron
        {
            Debug.Log("ingredientsInRecipe.Count: " + ingredientsInRecipe.Count);
            for (int i = 0; i < ingredientsInRecipe.Count; i++) //check if it's in the recipe
            {
                Debug.Log("Checking if cauldron ingredient " + cauldron.CurrentIngredients[j] + " = recipe ingredient: " + ingredientsInRecipe[i]);
                if (cauldron.CurrentIngredients[j] == ingredientsInRecipe[i])
                {
                    Debug.Log("Player placed a correct ingredient! " + ingredientsInRecipe[i]);
                   
                    if (cauldron.CurrentIngredients.Count > currentOrder.recipe.Length)
                    {
                        Debug.Log("There are too many ingredients for this recipe in the pot!");
                        numberOfCorrectIngredients = numberOfCorrectIngredients / cauldron.CurrentIngredients.Count;
                    }
                    else
                    {
                        Debug.Log("Correct ingredient added");
                        numberOfCorrectIngredients++;
                        ingredientsInRecipe.RemoveAt(i);
                    }
                }
            }
        }

        Debug.Log("Total number of correct ingredients:" + numberOfCorrectIngredients);
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
