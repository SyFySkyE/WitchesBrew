using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static event Action LevelCompleted;

    [SerializeField]
    private Cauldron cauldron;

    [SerializeField]
    private ScoreText scoreManager;

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

    bool paused = false; //to do: move to level manager?

    // Start is called before the first frame update
    private void Start()
    {
        currentOrder = orders[0]; //current order starts at first order
    }

    private void Update()
    {
        if(!paused)
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

    void MoveToNextOrderIfThereIsOne()
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
        double possibleScoreBasedOnTimer;
        //calculate quickness
        //make switch to change this based on timer

        //if red
        //possibleScore = possibleScore * redTimerScoreModifier;
        //if yellow
        //possibleScore = possibleScore * yellowTimerScoreModifier;
        //if green
        possibleScoreBasedOnTimer = baseScore * greenTimerScoreModifier;

        //calculate accuracy

        List<IngredientEnum> ingredientsInRecipe = currentOrder.recipe.ToList();

        int numberOfCorrectIngredients = 0;
        for (int j = 0; j < cauldron.CurrentIngredients.Count; j++) //for each ingredient in the cauldron
        {
            for (int i = 0; i < ingredientsInRecipe.Count; i++) //check if it's in the recipe
            {
                if (cauldron.CurrentIngredients[j] == ingredientsInRecipe[i])
                {
                    numberOfCorrectIngredients++;
                    ingredientsInRecipe.RemoveAt(i);
                }
            }
        }

        double accuracyPercent = (double)numberOfCorrectIngredients / currentOrder.recipe.Length;
        Debug.Log($"{currentOrder.name} was {accuracyPercent} accurate");

        currentOrder.score = accuracyPercent * possibleScoreBasedOnTimer;

        LevelManager.totalScore += Convert.ToInt32(currentOrder.score);
        cauldron.ClearIngredients();
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
