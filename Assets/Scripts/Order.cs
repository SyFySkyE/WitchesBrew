using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public List<BaseIngredient> IngredientsNeeded { get; private set; }

    public Order(List<BaseIngredient> ingredientsNeeded) // TODO should be interfaces
    {
        this.IngredientsNeeded = ingredientsNeeded;
    }
}
