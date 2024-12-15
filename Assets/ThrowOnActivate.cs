using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowOnActivate : MonoBehaviour
{
    private XRGrabInteractable grabbable;
    private XRBaseInteractor currentInteractor;
    private Rigidbody rb;

    // Reference to the camera (headset)
    public Camera xrCamera; // Assign this in the inspector or find it in the script

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
            // Get the direction of the ray (hand direction)
            Vector3 handDirection = rayInteractor.transform.forward;

            // Get the direction of the headset (camera direction)
            Vector3 headsetDirection = xrCamera.transform.forward;

            // Calculate the angle between the headset and the hand
            float angle = Vector3.Angle(headsetDirection, handDirection);
            Debug.Log("Angle between headset and hand: " + angle);

            // You can now adjust the throw direction based on the angle.
            // For example, you could scale the force or tweak the direction.
            Vector3 throwDirection = handDirection;

            // Apply force to the object in the direction of the hand
            rb.isKinematic = false; // Allow physics interaction
            rb.AddForce(throwDirection * 10f, ForceMode.VelocityChange); // Adjust force as needed
            Debug.Log("Force applied to object in direction: " + throwDirection);
        }
        else
        {
            Debug.LogWarning("The interactor is not an XRRayInteractor.");
        }
    }
}
