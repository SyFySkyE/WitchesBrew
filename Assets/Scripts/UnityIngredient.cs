using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityIngredient : MonoBehaviour
{
    [SerializeField] private IngredientEnum ingredient; // Can we dynamically choose our material on Start depending on what this is? Would that be desired?

    private void Start()
    {
        this.tag = "Ingredient";
    }

    public IngredientEnum GetIngredientType()
    {
        return this.ingredient;
    }
}
