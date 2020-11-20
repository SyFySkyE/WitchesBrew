using UnityEngine;

public class MouseOverHighlightable : MonoBehaviour
{
    Outline outlineScript;

    private void Start()
    {
        outlineScript = GetComponent<Outline>();
        outlineScript.enabled = false;
    }

    private void OnMouseOver()
    {
        outlineScript.enabled = true;
    }

    private void OnMouseExit()
    {
        outlineScript.enabled = false;
    }
}
