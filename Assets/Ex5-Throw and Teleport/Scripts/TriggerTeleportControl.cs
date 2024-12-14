using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerTeleportControl : MonoBehaviour
{
    public GameObject locomotionSystem;
    private TeleportationProvider teleportationProvider;
    private ContinuousMoveProviderBase moveProvider;
    public bool onEnterSetTeleportationProvider = false;
    public bool onEnterSetMoveProvider = false;
    public Material onTriggerEnterMaterial;
    private Material origMaterial;
    private Renderer objectRenderer;

    private void Awake()
    {
        teleportationProvider = locomotionSystem.GetComponentInChildren<TeleportationProvider>();
        moveProvider = locomotionSystem.GetComponentInChildren<ContinuousMoveProviderBase>();

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            origMaterial = objectRenderer.material;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            teleportationProvider.enabled = onEnterSetTeleportationProvider;
            Debug.Log("TeleportationProvider " + onEnterSetTeleportationProvider);

            moveProvider.enabled = onEnterSetMoveProvider;
            Debug.Log("ContinuousMoveProvider " + onEnterSetMoveProvider);

            if (objectRenderer != null && onTriggerEnterMaterial != null)
            {
                objectRenderer.material = onTriggerEnterMaterial;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            teleportationProvider.enabled = !onEnterSetTeleportationProvider;
            Debug.Log("TeleportationProvider " + !onEnterSetTeleportationProvider);

            moveProvider.enabled = !onEnterSetMoveProvider;
            Debug.Log("ContinuousMoveProvider " + !onEnterSetMoveProvider);

            if (objectRenderer != null && origMaterial != null)
            {
                objectRenderer.material = origMaterial;
            }
        }
    }
}
