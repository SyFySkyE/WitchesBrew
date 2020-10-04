using System;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static event Action LevelCompleted;



    [SerializeField]
    [Tooltip("Array of orders in the level")]
    private Order[] orders;

    private Order currentOrder;
    

    // Start is called before the first frame update
    private void Start()
    {
        RunOrderSequence();
    }

    /// <summary>
    /// Creates each order in a sequence, depending on the number of orders in the level
    /// </summary>
    private void RunOrderSequence()
    {
        foreach(Order order in orders)
        {
            currentOrder = order;

        }
    }

   



   
}
