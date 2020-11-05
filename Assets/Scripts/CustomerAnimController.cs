using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimController : MonoBehaviour
{
    private Animator customerAnim;

    // Start is called before the first frame update
    void Start()
    {
        customerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() // This is more of a showcase than how the implementation should be
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            customerAnim.SetInteger("Index", 0);
            customerAnim.SetTrigger("Enter");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            customerAnim.SetInteger("Index", 1);
            customerAnim.SetTrigger("Enter");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            customerAnim.SetInteger("Index", 2);
            customerAnim.SetTrigger("Enter");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            customerAnim.SetInteger("Index", 0);
            customerAnim.SetTrigger("Leave");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            customerAnim.SetInteger("Index", 1);
            customerAnim.SetTrigger("Leave");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            customerAnim.SetInteger("Index", 2);
            customerAnim.SetTrigger("Leave");
        }
    }
}
