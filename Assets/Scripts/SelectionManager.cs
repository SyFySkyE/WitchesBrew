using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    //[SerializeField]
    //private string selectableTag = "Ingredient";
    [SerializeField]
    private Material hightlightMaterial;
    //[SerializeField]
    //private Material defaultMaterial;
    


    private Transform _selection;
    //Outline
    // Update is called once per frame
    void Update()
    {
        //if (_selection != null)
        //{
        //    var selectionRenderer = _selection.GetComponent<Renderer>();
        //    selectionRenderer.material = defaultMaterial;
        //    _selection = null;
        //}

        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    var selection = hit.transform;
        //    //if (selection.CompareTag(selectableTag))
        //    //{
        //    //    var selectionRenderer = selection.GetComponent<Renderer>();
        //    //    if (selectionRenderer != null)
        //    //    {
        //    //        selectionRenderer.material = hightlightMaterial;
        //    //    }
        //    //}

        //}
        //var selection;
        //var selectionRenderer = selection.GetComponent<Renderer>();
        ////make default material the previous material of whatever is moused over (until it is no longer moused over)
        //if (selectionRenderer != null)
        //{
        //    selectionRenderer.material = hightlightMaterial;
        //}
        OnMouseOver();
    }

    private void OnMouseOver()
    {
        var selectionRenderer = GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = hightlightMaterial;
        }
    }

    private void OnMouseExit()
    {
        
    }
}
