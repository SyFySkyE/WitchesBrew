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

    public bool Paused = true; //to do: move to level manager?

    [SerializeField]
    CustomerTimer customer;

    [SerializeField]
    private TMP_Text orderText;

    [SerializeField]
    [Tooltip("Array of orders in the level")]
    private Order[] orders;

    [SerializeField]
    private RandomizeOrder randomizeOrder;

    private int currentOrderIndex = 0;

    private void Start()
    {

        if(randomizeOrder != null)
            randomizeOrder.RandomizeOrderArry(orders);
        CreateOrderInstances();

        currentOrder = orders[0]; //current order starts at first order
    }

    private void Update()
    {
        if (!Paused)
            UpdateCurrentOrderState();
    }

    private void TakeOrder()
    {
        dialogue1.OrderItem = currentOrder.recipeName;//////////////////////////////////////////////////////////////////////////DWIGHT
        dialogue2.OrderItem = currentOrder.recipeName;
        dialogue3.OrderItem = currentOrder.recipeName;
        Invoke("StartDialogue", 2f);
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
            Paused = true;
        }
    }

    private void OnDoneButtonPressed()
    {
        currentOrder.orderState = OrderState.Done;

        ////////////////////////////////////////////////////////////////////////DWIGHT******************************************************ACTIVE*************************************************

        FindObjectOfType<DialogueManager>().animator.SetBool("IsOpen", false);
        FindObjectOfType<DialogueManager>().animator.SetBool("LastDialogue", false);
        FindObjectOfType<DialogueManager>().animator.SetBool("IsOrder", false);

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

    private void StartDialogue() ///////////////////////////////////////////////////////////////////DWIGHT
    {

        CustomerAnimController.PlayEnterAnimation();
        if (CurrentCustomerNumber == 1)
        {
            BeginOrderDialogue(dialogue1);
        }
        else if (CurrentCustomerNumber == 2)
        {
            BeginOrderDialogue(dialogue2);
        }
        else if (CurrentCustomerNumber == 3)
        {
            BeginOrderDialogue(dialogue3);
        }
        else if (CurrentCustomerNumber == 4)
        {
            CurrentCustomerNumber = 1;
        }

        ++CurrentCustomerNumber;

    }

    //private void BeginDialogue(Dialogue dialogue) ///////////////////////////////////////////////////DWIGHT
    //{

    //    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    //}
    private void BeginOrderDialogue(Dialogue dialogue) ///////////////////////////////////////////////////DWIGHT
    {

        FindObjectOfType<DialogueManager>().StartOrderDialogue(dialogue);
        customer.Paused = false;

    }
}
