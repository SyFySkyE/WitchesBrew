using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCatcher : MonoBehaviour
{
    [SerializeField] private ParticleSystem cauldronVfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            other.gameObject.SetActive(false);
            cauldronVfx.Play();
        }
    }
}
