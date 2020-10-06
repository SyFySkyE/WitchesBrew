using TMPro;
using UnityEngine;

public class IngredientMousedOverText : MonoBehaviour
{
    [SerializeField]
    PlayerGrab playerGrab;

    private TMP_Text textBox;
    private string ingredientName;

    private void Start()
    {
        textBox = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        CheckForMouseHover();

        if(playerGrab.heldIngredient == IngredientEnum.None)
            UpdateText();
    }

    private void UpdateText()
    {
        textBox.text = ingredientName;
    }

    private void CheckForMouseHover()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); // If I was a real good boi, I would abstract mouse pos so I could easily sub touch func or controller
        RaycastHit hitInfo;

        if (Physics.Raycast(cameraRay, out hitInfo, 100))
        {
            if (hitInfo.collider.tag == "Ingredient")
            {
                ingredientName = hitInfo.collider.GetComponent<UnityIngredient>().GetIngredientType().ToString();
            }
        }
    }
}
