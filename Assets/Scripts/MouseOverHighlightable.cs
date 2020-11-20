using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverHighlightable : MonoBehaviour
{
    [SerializeField]
    Material highlightMaterial;

    private Material defaultMaterial;
    private MeshRenderer[] meshRenderers;

    private 

    // Start is called before the first frame update
    void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            defaultMaterial = meshRenderer.material;
        }
        
    }

    private void OnMouseOver()
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material = highlightMaterial;
        }
    }

    private void OnMouseExit()
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material = defaultMaterial;
        }
    }
}
