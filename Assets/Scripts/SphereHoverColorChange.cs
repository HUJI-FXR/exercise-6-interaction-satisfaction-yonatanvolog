using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SphereHoverColorChange : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Renderer sphereRenderer;
    private Material originalMaterial;
    public Material greenMaterial;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        sphereRenderer = GetComponent<Renderer>();
        originalMaterial = sphereRenderer.material;

        grabInteractable.hoverEntered.AddListener(OnHoverEnter);
        grabInteractable.hoverExited.AddListener(OnHoverExit);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        sphereRenderer.material = greenMaterial;
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        sphereRenderer.material = originalMaterial;
    }
}
