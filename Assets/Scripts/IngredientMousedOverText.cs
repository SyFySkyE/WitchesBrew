using TMPro;
using UnityEngine;

public class IngredientMousedOverText : MonoBehaviour
{
    [Header("Mouse Hover Parameters")]
    [Tooltip("How much to offset text from mouse")]
    [SerializeField] private Vector3 mousePosOffset;
    [Tooltip("Use to control how fast text goes to mouse pos")]
    [SerializeField] private float moveSpeedMultiplier;
    [Tooltip("How big the delta between mouse pos and text box pos can be before we stop lerping the POS and force snap it. This is used because if the user dragged the mouse from a large enough distance, it would take too long to lerp to where it should be")]
    [SerializeField] private float maxDistanceBeforeTextSnapsToMousePos;

    [Header("How quickly text fades in and out")]
    [SerializeField] private float textFadeMultiplier;

    private TMP_Text textBox;
    private bool isHoveringOverIngred;
    private bool isFading;

    private void Start()
    {
        textBox = GetComponent<TMP_Text>();
        textBox.text = string.Empty;
    }

    private void Update()
    {
        CastRay();
        FollowCursor();
        FadeText();
    }

    private void CastRay()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); // If I was a real good boi, I would abstract mouse pos so I could easily sub touch func or controller
        RaycastHit hitInfo;        

        if (Physics.Raycast(cameraRay, out hitInfo, 100))
        {
            if (hitInfo.collider.tag == "Ingredient")
            {
                if (!isHoveringOverIngred) // So we're not GetComponent'ing every frame
                {
                    isHoveringOverIngred = true;
                    ChangeText(hitInfo.collider.gameObject.GetComponent<UnityIngredient>().GetIngredientType());
                    isFading = false;
                }
            }
            else
            {
                isHoveringOverIngred = false;
                isFading = true;
            }
        }
    }

    private void FollowCursor() 
    {
        if (isHoveringOverIngred)
        {
            if (Vector3.Distance(textBox.transform.position, Input.mousePosition + mousePosOffset) > maxDistanceBeforeTextSnapsToMousePos)
            {
                textBox.transform.position = Input.mousePosition + mousePosOffset;
            }
        }
        
        textBox.transform.position = Vector3.Lerp(textBox.transform.position, Input.mousePosition + mousePosOffset, moveSpeedMultiplier * Time.deltaTime); // Really shouldn't need to do this IF we're not hovering over anything
    }

    private void ChangeText(IngredientEnum newIngredient)
    {
        textBox.text = newIngredient.ToString();
    }

    private void FadeText()
    {
        if (isFading && textBox.color != Color.clear)
        {
            textBox.color = Color.Lerp(textBox.color, Color.clear, textFadeMultiplier * Time.deltaTime);
        }
        else if (!isFading && textBox.color != Color.white) // Should we expose what color to lerp to?
        {
            textBox.color = Color.Lerp(textBox.color, Color.white, textFadeMultiplier * Time.deltaTime);
        }
    }
}
