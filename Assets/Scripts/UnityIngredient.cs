using UnityEditor.SceneManagement;
using UnityEngine;

public class UnityIngredient : MonoBehaviour // Is responisible for both the container and GO ingred, infringes on proper SoC!
{
    [SerializeField] private IngredientEnum ingredient;
    [SerializeField] private Vector3 cauldronDropLocation;

    public GameObject IngredientGORep { get; private set; }
    private string resourcePath = "IngredientPrefabs/";    
    private float minYBeforeDisable = -10f; // How far the GO rep can fall before being disabled
    private Rigidbody ingredRb;

    private void Start()
    {
        this.tag = "Ingredient";
        InstantiateIngredient();        
    }

    private void Update()
    {
        if (this.IngredientGORep.transform.position.y <= minYBeforeDisable)
        {
            this.IngredientGORep.transform.position = Vector3.zero;
            ingredRb.useGravity = false;            
            this.IngredientGORep.SetActive(false);
        }
    }

    public IngredientEnum GetIngredientType()
    {
        return this.ingredient;
    }

    private void OnMouseDown()
    {
        IngredientGORep.SetActive(true);
    }

    public void OnGrab()
    {
        if (ingredRb)
        {
            DestroyImmediate(ingredRb); // TODO This isn't the right way to do this, this is to prevent a bug where on first drop things the object drops at a normal speed but every time after it gets faster and faster, like terminal velocity doesn't reset or something
            ingredRb = null;
        }
        
        ingredRb = IngredientGORep.AddComponent<Rigidbody>(); // TODO See above
        ingredRb.useGravity = false;
    }

    public void DropIngredientIn()
    {
        IngredientGORep.transform.position = cauldronDropLocation;
    }

    private void InstantiateIngredient()
    {
        string ingredientToSpawn = string.Empty; // Can't leave this uninitialized

        #region Decide what ingredient to use based on this ingredient type

        switch (this.ingredient)
        {
            case IngredientEnum.BabyShoesNeverWorn:
                ingredientToSpawn = "Baby_Shoes";
                break;

            case IngredientEnum.Eyeballs:
                ingredientToSpawn = "Eyeball";
                break;

            case IngredientEnum.FrogLegs:
                ingredientToSpawn = "Frog_Legs";
                break;

            case IngredientEnum.PumpkinSpice:
                ingredientToSpawn = "Empty";
                Debug.Log($"GO equavilent of type: {this.ingredient} is not set, setting GO rep to empty");
                break;

            case IngredientEnum.RatTail:
                ingredientToSpawn = "Rat_Tail";
                break;

            case IngredientEnum.Snails:
                ingredientToSpawn = "Snail";
                break;

            case IngredientEnum.Tears:
                ingredientToSpawn = "Empty";
                Debug.Log($"GO equavilent of type: {this.ingredient} is not set, setting GO rep to empty");
                break;

            case IngredientEnum.Vanilla:
                ingredientToSpawn = "Vanilla";
                break;

            case IngredientEnum.Worms:
                ingredientToSpawn = "Worms";
                break;

            default:
                ingredientToSpawn = "Empty";
                Debug.Log($"GO equavilent of type: {this.ingredient} is not set, setting GO rep to empty");
                break;
        }

        #endregion

        IngredientGORep = Instantiate(Resources.Load<GameObject>(resourcePath + ingredientToSpawn));
        IngredientGORep.AddComponent<BoxCollider>();
        IngredientGORep.GetComponent<BoxCollider>().isTrigger = true;
        IngredientGORep.gameObject.tag = this.gameObject.tag;
        IngredientGORep.transform.SetParent(this.transform);
        IngredientGORep.SetActive(false);
    }
}
