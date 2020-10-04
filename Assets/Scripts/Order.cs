using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Orders", order = 1)]
public class Order : ScriptableObject //to do: create scriptable objects of recipes
{
    public string recipeName;
    public bool isDone = false;

    public List<BaseIngredient> Recipe { get; private set; }

    public Order(List<BaseIngredient> recipe) // TODO should be interfaces
    {
        this.Recipe = recipe;
    }

    private void DisplayIngredientsInRecipe()
    {
        int ingredientsLeftToDisplay = Recipe.Count;

        while (ingredientsLeftToDisplay > 0)
        {
            Debug.Log("These are the ingredients I need!");
            foreach (BaseIngredient ingrdient in Recipe)
            {
                Debug.Log($"I'll need: {ingrdient}");
            }

            ingredientsLeftToDisplay--;
        }
    }

}


