using System.Collections;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField]
    private float ingredientDistanceFromCamera = 1.1f;
    private int counter = 0;

    public RaycastHit HitInfo
    {
        get; set;
    }

    public GameObject bellArrow;
    public IngredientEnum HeldIngredient;
    private GameObject ingredGORep;


    private UnityIngredient currentIngredient;

    [HideInInspector]
    public float zOffset = -1.5f;

    private void Update()
    {
        CameraRay();

        if (ingredGORep != null)
        {
            if (Input.GetMouseButton(0))
            {
                Cursor.visible = false;
                Vector3 mousePosToScreen = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + ingredientDistanceFromCamera));               
                ingredGORep.transform.position = mousePosToScreen;
            }
        }

        if (counter >= 3)
        {
            bellArrow.SetActive(true);
            //Debug.Log("activates arrow");
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "Bell")
                {
                    counter = 0;
                    bellArrow.SetActive(false);
                }
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
                    currentIngredient = hitInfo.collider.GetComponent<UnityIngredient>();
                    hitInfo.collider.GetComponent<UnityIngredient>().OnGrab();
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
                        DropIngredient();
                        counter++;
                        // UseThis Code to grab stuff from Audiomanager. We will need to identify what is liquid and solid. 
                    }
                }
                else
                {
                    if (this.HeldIngredient != IngredientEnum.None)
                    {
                        Debug.Log($"You dropped ingredient: {HeldIngredient}");
                        DropIngredient();
                    }
                }                
            }
        }
    }

    private void DropIngredient()
    {
        ingredGORep.GetComponent<Rigidbody>().useGravity = true;
        currentIngredient = null;
        Cursor.visible = true;
        ingredGORep = null;
        HeldIngredient = IngredientEnum.None;
    }
}
