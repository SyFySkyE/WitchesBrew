﻿using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public List<IngredientEnum> CurrentIngredients { get; private set; } // TODO switch to interfaces ?? enums might be better

    private void Start()
    {
        this.tag = "Cauldron";
        CurrentIngredients = new List<IngredientEnum>();
    }

    public void AddIngredient(IngredientEnum ingredientToAdd)
    {
        CurrentIngredients.Add(ingredientToAdd);

        switch (ingredientToAdd)
        {
            case IngredientEnum.BabyShoesNeverWorn:
                break;

            case IngredientEnum.Eyeballs:
                break;

            case IngredientEnum.FrogLegs:
                break;

            case IngredientEnum.RatTail:
                break;

            case IngredientEnum.Snails:
                break;

            case IngredientEnum.Tears:
                break;

            case IngredientEnum.Vanilla:
                break;

            case IngredientEnum.Worms:
                break;
        }

        LogIngredients();
    }

    public void ClearIngredients()
    {
        CurrentIngredients.Clear();
    }

    private void LogIngredients()
    {
        Debug.Log("List of ingredients within the cauldron: ");

        foreach (IngredientEnum ingredient in CurrentIngredients)
        {
            Debug.Log(ingredient);
        }
    }

    private void OnOrderCompleted(Order o)
    {
        ClearIngredients();
    }

    private void OnMouseUp()
    {
        Debug.Log("The consequences will never be the sam");
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
