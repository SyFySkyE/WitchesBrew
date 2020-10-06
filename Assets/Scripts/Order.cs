using UnityEngine;

public enum OrderState { NotStarted, InProgress, Done }

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Orders", order = 1)]
public class Order : ScriptableObject //to do: create scriptable objects of recipes
{
    [HideInInspector]
    public double score;
    public string recipeName;

    public IngredientEnum[] recipe;
    public OrderState orderState = OrderState.NotStarted;
    int ingredientsLeftToCombine;

    public Order()
    {
        ingredientsLeftToCombine = recipe.Length;
    }

    private void TrackOrderProgress() //to do, implement order tracking
    {
        while (ingredientsLeftToCombine > 0)
        {
            Debug.Log("These are the ingredients I need!");
            foreach (IngredientEnum ingredient in recipe)
            {
                Debug.Log($"I'll need: {ingredient}");
            }

            ingredientsLeftToCombine--;
        }
    }

}


