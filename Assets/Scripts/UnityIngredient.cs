using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityIngredient : MonoBehaviour
{
    [SerializeField] private IngredientEnum ingredient;

    private void Start()
    {
        this.tag = "Ingredient";
    }

    public IngredientEnum GetIngredientType()
    {
        return this.ingredient;
    }
}
