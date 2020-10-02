using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIngredient : ScriptableObject, IInteractable
{
    public BaseIngredient Ingredient { get; private set; }

    public void Interact()
    {
        
    }
}
