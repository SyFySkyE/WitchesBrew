using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    [Header("Rotation Parameters")]
    [Tooltip("This get multiplied with DeltaTime")]
    [SerializeField] private float speedMultiplier;
    [Tooltip("Rotation along the X axis")]
    [SerializeField] private float minRoll;
    [Tooltip("Rotation along the X axis")]
    [SerializeField] private float maxRoll;
    [Tooltip("Rotation along the Y axis")]
    [SerializeField] private float minPitch;
    [Tooltip("Rotation along the Y axis")]
    [SerializeField] private float maxPitch;

    [Header("Has a small chance of choosing this rotation")]
    [SerializeField] private Vector3[] specialRots;
    [Tooltip("Liklihood of choosing special rot on next random rot calculation. In percent.")]
    [SerializeField][Range(0f, 1f)] private float specialRotChance;
    [Tooltip("If we chose a special rot last time, can we pick it again immediately after?")]
    [SerializeField] private bool canRepeat; // What happens if this is set to true and chance is set to 1? Probably breaks shit.

    private Quaternion rotationToLerpTo;
    private bool hasPickedSpecialRot;

    // Did you know? Start is called before the first frame update
    void Start()
    {
        ChooseNewRandomClampedRotation();
    }

    private void ChooseNewRandomClampedRotation() // Looked a little off rotating the Yaw, think the object itself is not perfectly centered which is fine
    {
        if (specialRotChance >= Random.Range(0f, 1f))
        {
            if (hasPickedSpecialRot && !canRepeat) // If we picked a special rot last time and we can't repeat it, force choose a new rot
            {
                ChooseRandomRot();
            }
            else
            {
                ChooseSpecialRot();
            }
        }
        else
        {
            ChooseRandomRot();
        }        
    }

    private void ChooseSpecialRot()
    {
        rotationToLerpTo = Quaternion.Euler(specialRots[Random.Range(0, specialRots.Length)]);
        hasPickedSpecialRot = true;
    }

    private void ChooseRandomRot()
    {
        rotationToLerpTo = Quaternion.Euler(new Vector3(Random.Range(minRoll, maxRoll), Random.Range(minPitch, maxPitch), 0f));
        hasPickedSpecialRot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localRotation != rotationToLerpTo) // Lerp to new rotation until we get there
        {
            this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation, rotationToLerpTo, speedMultiplier * Time.deltaTime);
        }
        else // We're there? Choose a new rotation
        {
            if (canRepeat && specialRotChance >= 1f)
            {
                Debug.Log($"{this.gameObject} shouldn't have set canRepeat to true and a 100% specialRotChance since that would cause an infinite loop. Disabling script.");
                this.enabled = false;
            }
            else
            {
                ChooseNewRandomClampedRotation();
            }            
        }
    }
}
