using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static event Action LevelCompleted;

    [SerializeField]
    private CustomerTimer customerTimer;

    [SerializeField]
    private Cauldron cauldron;

    [SerializeField]
    private double baseScore = 100;

    [SerializeField]
    [Tooltip("Multiplied by the starter possible score to calculate the new possible score, based on what area of the timer the player completes the order in")]
    [Range(0, 1)]
    private double greenTimerScoreModifier = 0.9,
        yellowTimerScoreModifier = 0.8,
        redTimerScoreModifier = 0.5;

    [SerializeField]
    private TMP_Text orderText;

    [SerializeField]
    [Tooltip("Array of orders in the level")]
    private Order[] orders;

    private int currentOrderIndex = 0;
    private Order currentOrder;
    private bool paused = false; //to do: move to level manager?

    // Start is called before the first frame update
    private void Start()
    {
        currentOrder = orders[0]; //current order starts at first order
    }

    private void Update()
    {
        if (!paused)
            UpdateCurrentOrderState();
    }

    private void TakeOrder()
    {
        orderText.text = $"I would like to order a {currentOrder.name}";
    }

    private void UpdateCurrentOrderState()
    {
        switch (currentOrder.orderState)
        {
            case OrderState.NotStarted:
                TakeOrder();
                currentOrder.orderState = OrderState.InProgress;
                break;
            case OrderState.InProgress:
                break;
            case OrderState.Done:
                ScoreOrder();
                MoveToNextOrderIfThereIsOne();
                break;
        }
    }

    private void MoveToNextOrderIfThereIsOne()
    {
        if (currentOrderIndex + 1 < orders.Length) //if we aren't on the last order yet, move to next order
        {
            currentOrderIndex++;
            currentOrder = orders[currentOrderIndex];
        }
        else  //if we are on the last order, end level
        {
            LevelCompleted?.Invoke();
            paused = true;
        }
    }

    /// <summary>
    /// Calculates the order score to add to the total score based on quickness and accuracy
    /// </summary>
    private void ScoreOrder()
    {
        currentOrder.score = GetOrderAccuracyPercent() * GetNewBaseScoreBasedOnTimer();

        LevelManager.totalScore += Convert.ToInt32(currentOrder.score);
        cauldron.ClearIngredients();
    }

    /// <summary>
    /// Multiplies the base score by a modifier depending on if the timer is in the green, yellow, or red state
    /// </summary>
    /// <returns>Returns a new maximum possible score</returns>
    private double GetNewBaseScoreBasedOnTimer()
    {
        double possibleScoreBasedOnTimer = baseScore;

        switch (customerTimer.CurrentSatisfaction)
        {
            case CustomerHappiness.Green:
                possibleScoreBasedOnTimer = baseScore * greenTimerScoreModifier;
                break;
            case CustomerHappiness.Yellow:
                possibleScoreBasedOnTimer = baseScore * yellowTimerScoreModifier;
                break;
            case CustomerHappiness.Red:
                possibleScoreBasedOnTimer = baseScore * redTimerScoreModifier;
                break;
            case CustomerHappiness.Fail: //TODO show fail UI
                break;
        }
        return possibleScoreBasedOnTimer;
    }

    private double GetOrderAccuracyPercent() //TODO proofread accuracy calculation, see if anything should be serialized
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

    private void OnDoneButtonPressed()
    {
        currentOrder.orderState = OrderState.Done;
    }

    private void OnEnable()
    {
        CompleteOrderButton.DoneButtonClicked += OnDoneButtonPressed;
    }

    private void OnDisable()
    {
        CompleteOrderButton.DoneButtonClicked -= OnDoneButtonPressed;
    }
}
