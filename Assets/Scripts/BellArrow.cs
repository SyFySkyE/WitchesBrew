using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellArrow : MonoBehaviour
{
    public GameObject pointer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "Bell")
                {
                    DelArrow();
                }
            }
        }
    }

    public void DelArrow()
    {
        pointer.SetActive(false);
        Debug.Log("deactivates arrow");
    }
}
