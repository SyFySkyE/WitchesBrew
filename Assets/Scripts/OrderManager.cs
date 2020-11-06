using System;
using TMPro;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public int CurrentCustomerNumber = 1;

    public static event Action LevelCompleted;
    public static event Action<Order> OrderCompleted;

    public Order currentOrder { get; set; }

    [SerializeField]
    private TMP_Text orderText;

    [SerializeField]
    [Tooltip("Array of orders in the level")]
    private Order[] orders;

    [SerializeField]
    private RandomizeOrder randomizeOrder;

    private int currentOrderIndex = 0;
    
    private bool paused = false; //to do: move to level manager?

    private void Start()
    {

        if(randomizeOrder != null)
            randomizeOrder.RandomizeOrderArry(orders);
        CreateOrderInstances();

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

        Invoke("StartDialogue", 5f);//////////////////////////////////////////////////////////////////////////

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
                OrderCompleted?.Invoke(currentOrder);
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

    private void CreateOrderInstances() //creates a unique instance of an OrderRecipe recipe
    {
        for (int i = 0; i < orders.Length; i++)
        {
            orders[i] = Instantiate(orders[i]);
        }
    }

    private void StartDialogue() ///////////////////////////////////////////////////////////////////
    {

        if (CurrentCustomerNumber == 1)
        {
            BeginDialogue(dialogue1);
        }
        else if (CurrentCustomerNumber == 2)
        {
            BeginDialogue(dialogue2);
        }
        else if (CurrentCustomerNumber == 3)
        {
            BeginDialogue(dialogue3);
        }
        else if (CurrentCustomerNumber == 4)
        {
            CurrentCustomerNumber = 1;
        }

        ++CurrentCustomerNumber;

    }

    private void BeginDialogue(Dialogue dialogue) ///////////////////////////////////////////////////
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
}
