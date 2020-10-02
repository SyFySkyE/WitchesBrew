using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private IngredientEnum heldIngredient;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); // If I was a real good boi, I would abstract mouse pos so I could easily sub touch func or controller
        RaycastHit hitInfo;

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(cameraRay, out hitInfo, 100))
            {
                if (hitInfo.collider.tag == "Ingredient")
                {
                    heldIngredient = hitInfo.collider.GetComponent<UnityIngredient>().GetIngredientType();
                    Debug.Log($"You picked up ingredient: {heldIngredient}");
                }
            }
        }        
        else if (Input.GetButtonUp("Fire1")) // TODO we're no longer grabbing, we're placing. Violating Single respsonigility! Please do not let this become a homonocolus class like that one project you know...
        {
            if (Physics.Raycast(cameraRay, out hitInfo, 100))
            {
                if (hitInfo.collider.tag == "Cauldron")
                {
                    if (this.heldIngredient != IngredientEnum.None)
                    {
                        hitInfo.collider.GetComponent<Cauldron>().AddIngredient(heldIngredient);
                        Debug.Log($"You put ingredient: {heldIngredient} in cauldron");
                        heldIngredient = IngredientEnum.None;
                    }                    
                }
                else
                {
                    if (this.heldIngredient != IngredientEnum.None)
                    {
                        Debug.Log($"You dropped ingredient: {heldIngredient}");
                        heldIngredient = IngredientEnum.None;
                    }                    
                }
            }
        }
    }
}
