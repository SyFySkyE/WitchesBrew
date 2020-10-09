using System.Collections;
using System.Collections.Generic;
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

    
}

