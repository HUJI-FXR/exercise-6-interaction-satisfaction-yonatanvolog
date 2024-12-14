using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerParalize : MonoBehaviour
{
    public Material whiteMat;
    private Rigidbody rb;
    private Renderer objectRenderer;
    public GameObject teleportationProvider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        objectRenderer = GetComponent<Renderer>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        //teleportationProvider = FindObjectOfType<TeleportationProvider>();

    }

    private void Start()
    {
        ParalyzePlayer();
    }

    private void OnEnable()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }
    }

    private void OnDisable()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        objectRenderer.material = whiteMat;
        rb.constraints = RigidbodyConstraints.None;
        UnparalyzePlayer();
    }

    private void UnparalyzePlayer()
    {
        teleportationProvider.SetActive(true);
        Debug.Log("Teleportation enabled. Player has been unparalyzed.");
        Destroy(gameObject, 5f);
    }

    private void ParalyzePlayer()
    {
        teleportationProvider.SetActive(false);
        Debug.Log("Teleportation disabled. Player is paralyzed.");
    }
}
