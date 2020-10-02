using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private int numberOfIngredientsPerRecipe;

    private Order currentOrder;
    private List<IngredientEnum> listOfIngredients; // TODO should be an array!!! Decide length at runtime
    private int numberOfIngredientsLeft;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateIngredientList();
        CreateOrder();
    }

    private void InstantiateIngredientList()
    {
        listOfIngredients = new List<IngredientEnum>();
        foreach (IngredientEnum ingred in Enum.GetValues(typeof(IngredientEnum)))
        {
            if (ingred != IngredientEnum.None)
            {
                listOfIngredients.Add(ingred); // NOTE we're adding 0 index (none) in this Gonna change this later
            }
        }
    }

    private void CreateOrder()
    {
        numberOfIngredientsLeft = numberOfIngredientsPerRecipe;

        while (numberOfIngredientsLeft > 0)
        {
            IngredientEnum newIngred = listOfIngredients[UnityEngine.Random.Range(0, listOfIngredients.Count)];
            numberOfIngredientsLeft--;            
        }

        Debug.Log("These are the ingredients I need!");
        foreach (IngredientEnum ingred in listOfIngredients)
        {
            Debug.Log($"I'll need: {ingred}");
        }
    }
}
