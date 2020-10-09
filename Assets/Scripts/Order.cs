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

    private void OnEnable()
    {
        orderState = OrderState.NotStarted;
    }

}


