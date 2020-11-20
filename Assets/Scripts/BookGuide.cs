using UnityEngine;

public class BookGuide : MonoBehaviour
{
    public GameObject pointer;

    private void Start()
    {
        pointer.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "RecipeBook")
                {
                    DelArrow();
                }
            }
        }
    }

    private void OnLevelStarted()
    {
        pointer.SetActive(true);
    }

    public void DelArrow()
    {
        pointer.SetActive(false);
    }

    private void OnEnable()
    {
        TipGoalText.LevelStarted += OnLevelStarted;
    }

    private void OnDisable()
    {
        TipGoalText.LevelStarted -= OnLevelStarted;
    }
}
