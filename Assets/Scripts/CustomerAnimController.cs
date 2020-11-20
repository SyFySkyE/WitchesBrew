using System.Collections;
using UnityEngine;

public class CustomerAnimController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] customers;

    private static Animator customerAnim;
    private static SpriteRenderer spriteRenderer;
    private static int customerIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        customerAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = customers[customerIndex];
    }

    public static void PlayEnterAnimation()
    {
        customerAnim.SetInteger("Index", 1);
        customerAnim.SetTrigger("Enter");
    }

    public static void PlayExitAnimation()
    {
        customerAnim.SetInteger("Index", 1);
        customerAnim.SetTrigger("Leave");
    }

    private void OnOrderCompleted(Order o)
    {
        PlayExitAnimation();
        StartCoroutine(WaitToSwitchCustomer());
    }

    IEnumerator WaitToSwitchCustomer()
    {
        yield return new WaitForSeconds(2); //magic number, very bad
        customerIndex++;
        spriteRenderer.sprite = customers[customerIndex];
    }

    private void OnEnable()
    {
        OrderManager.OrderCompleted += OnOrderCompleted;
    }

    private void OnDisable()
    {
        OrderManager.OrderCompleted -= OnOrderCompleted;
    }

    private void AnimationTestDemo()
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
