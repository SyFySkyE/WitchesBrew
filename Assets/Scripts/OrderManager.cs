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
        

        listOfIngredients = new List<IngredientEnum>();
        foreach (IngredientEnum ingred in Enum.GetValues(typeof(IngredientEnum)))
        {
            listOfIngredients.Add(ingred); // NOTE we're adding 0 index (none) in this Gonna change this later
            
        }

        CreateOrder();
    }

    private void CreateOrder()
    {
        numberOfIngredientsLeft = numberOfIngredientsPerRecipe;

        while (numberOfIngredientsLeft > 0)
        {
            IngredientEnum newIngred = listOfIngredients[UnityEngine.Random.Range(1, listOfIngredients.Count - 1)];
            numberOfIngredientsLeft--;
            Debug.Log(newIngred);
        }
    }
}
