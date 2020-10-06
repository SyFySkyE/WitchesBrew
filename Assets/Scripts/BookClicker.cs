using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookClicker : MonoBehaviour
{

    public GameObject RecipeBook;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

             if (Physics.Raycast(ray, out hit,100.0f))
             {
                 if(hit.collider.tag == "RecipeBook")
                 {
                    Debug.Log("You Opened book");
                    OpenBook();
                 }
             }
        }
    }

    public void OpenBook()
    {
        RecipeBook.SetActive(true);
    }

}
