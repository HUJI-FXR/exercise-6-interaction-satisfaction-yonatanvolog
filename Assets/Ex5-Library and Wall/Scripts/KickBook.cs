using UnityEngine;

public class KickBook : MonoBehaviour
{
    public Vector3 kickDirection = Vector3.back; // Direction of the kick
    public float kickForce = 5f; // Strength of the kick

    private Rigidbody rb;

    private void Start()
    {
        // Ensure the object has a Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on the object! Adding one automatically.");
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    public void ApplyKick()
    {
        // Apply an impulse force in the specified direction
        rb.AddForce(kickDirection.normalized * kickForce, ForceMode.Impulse);
        Debug.Log($"Applied kick force of {kickForce} in direction {kickDirection}.");
    }
}
