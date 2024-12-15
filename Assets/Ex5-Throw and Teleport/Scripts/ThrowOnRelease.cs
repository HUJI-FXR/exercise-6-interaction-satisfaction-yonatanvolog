using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowOnRelease: MonoBehaviour
{
    private XRGrabInteractable grabbable;
    private XRBaseInteractor currentInteractor;
    private Rigidbody rb;
    public float throwForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        // Subscribe to the SelectEntered event to know when the object is grabbed
        grabbable.onSelectEntered.AddListener(OnGrabbed);
        
        // Subscribe to the SelectExited event to know when the object is released
        grabbable.onSelectExited.AddListener(OnReleased);

        Debug.Log("ThrowOnActivate script started.");
    }

    // Called when the object is grabbed
    private void OnGrabbed(XRBaseInteractor interactor)
    {
        currentInteractor = interactor; // Store the interactor
        Debug.Log("Object grabbed by: " + interactor.name);
    }

    // Called when the object is released
    private void OnReleased(XRBaseInteractor interactor)
    {
        if (currentInteractor is XRRayInteractor rayInteractor)
        {
            // Get the direction of the ray
            Vector3 throwDirection = rayInteractor.transform.forward;
            Debug.Log("Throwing in direction: " + throwDirection);

            // Apply force to the object in the direction of the ray
            rb.isKinematic = false; // Allow physics interaction
            rb.AddForce(throwDirection * throwForce, ForceMode.VelocityChange); // Adjust force as needed
            Debug.Log("Force applied to object.");
        }
        else
        {
            Debug.LogWarning("The interactor is not an XRRayInteractor.");
        }
    }
}