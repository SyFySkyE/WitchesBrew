using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverHighlightable : MonoBehaviour
{
    [SerializeField]
    Material highlightMaterial;

    private Material defaultMaterial;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.material;
    }

    private void OnMouseOver()
    {
        meshRenderer.material = highlightMaterial;
    }

    private void OnMouseExit()
    {
        meshRenderer.material = defaultMaterial;
    }
}
