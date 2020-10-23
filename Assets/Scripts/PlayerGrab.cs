using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public IngredientEnum HeldIngredient;
    private GameObject ingredGORep;

    public float zOffset = -1.5f;

    private void Update()
    {
        CameraRay();

        if (ingredGORep != null)
        {
            if (Input.GetMouseButton(0))
            {
                Cursor.visible = false;
                Vector3 mousePosToScreen = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));                
                ingredGORep.transform.position = mousePosToScreen;
            }
            else
            {
                ingredGORep.GetComponent<Rigidbody>().useGravity = true;
                ingredGORep = null;
                Cursor.visible = true;
            }
        }
    }    

    private void CameraRay()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); // If I was a real good boi, I would abstract mouse pos so I could easily sub touch func or controller
        RaycastHit hitInfo;

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(cameraRay, out hitInfo, 100))
            {
                if (hitInfo.collider.tag == "Ingredient")
                {
                    HeldIngredient = hitInfo.collider.GetComponent<UnityIngredient>().GetIngredientType();
                    ingredGORep = hitInfo.collider.GetComponent<UnityIngredient>().IngredientGORep;
                    Debug.Log($"You picked up ingredient: {HeldIngredient}");
                }
            }
        }
        else if (Input.GetButtonUp("Fire1")) // TODO we're no longer grabbing, we're placing. Violating Single respsonigility! Please do not let this become a homonocolus class like that one project you know...
        {
            if (Physics.Raycast(cameraRay, out hitInfo, 100))
            {
                if (hitInfo.collider.tag == "Cauldron")
                {
                    if (this.HeldIngredient != IngredientEnum.None)
                    {
                        hitInfo.collider.GetComponent<Cauldron>().AddIngredient(HeldIngredient);
                        Debug.Log($"You put ingredient: {HeldIngredient} in cauldron");
                        HeldIngredient = IngredientEnum.None;
                    }
                }
                else
                {
                    if (this.HeldIngredient != IngredientEnum.None)
                    {
                        Debug.Log($"You dropped ingredient: {HeldIngredient}");
                        HeldIngredient = IngredientEnum.None;
                    }
                }
            }
        }
    }
}
