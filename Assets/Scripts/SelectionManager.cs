using MK.Toon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private string selectableTag = "Selectable";

    [SerializeField]
    private Material highlightMaterial;

    [SerializeField]
    private Material defaultMaterial;

    private Transform _selection;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (_selection != null)
        {
            
        }
    }
}
