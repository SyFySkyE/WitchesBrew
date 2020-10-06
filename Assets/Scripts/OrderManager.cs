using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static event Action LevelCompleted;

    [SerializeField]
    double possibleScore = 100;

    [SerializeField]
    [Tooltip("Multiplied by the starter possible score to calculate the new possible score, based on what area of the timer the player completes the order in")]
    [Range(0,1)]
    double greenTimerScoreModifier = 0.9, 
        yellowTimerScoreModifier = 0.8, 
        redTimerScoreModifier = 0.5;

    [SerializeField]
    private TMP_Text scoreText, orderText;

    [SerializeField]
    [Tooltip("Array of orders in the level")]
    private Order[] orders;

    private int currentOrderIndex = 0;
    private Order currentOrder;

    // Start is called before the first frame update
    private void Start()
    {
        currentOrder = orders[0]; //current order starts at first order
    }

    private void Update()
    {
        UpdateCurrentOrderState();
    }

    private void TakeOrder()
    {
        orderText.text = $"I would like to order {currentOrder}";
        //allow the player to drag stuff until they hit the done buttone

        //if done button pressed
        //currentOrder.OrderState = OrderState.Done

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
                //allow the player to make the order
                break;
            case OrderState.Done:
                ScoreOrder();
                currentOrderIndex++; //move to next order
                currentOrder = orders[currentOrderIndex];
                break;
        }
    }

    /// <summary>
    /// Calculates the order score to add to the total score based on quickness and accuracy
    /// </summary>
    private void ScoreOrder()
    {

        //calculate quickness
            //make switch to change this based on timer

            //if red
                //possibleScore = possibleScore * redTimerScoreModifier;
            //if yellow
                //possibleScore = possibleScore * yellowTimerScoreModifier;
            //if green
                possibleScore = possibleScore * greenTimerScoreModifier;

        //calculate accuracy
        double scoreBasedOnAccuracy = 

        currentOrder.score = scoreBasedOnAccuracy / possibleScore;

        ScoreManager.totalScore += Convert.ToInt32(orderScore);
    }






}
