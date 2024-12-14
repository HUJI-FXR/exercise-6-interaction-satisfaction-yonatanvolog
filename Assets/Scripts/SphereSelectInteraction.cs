using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SphereSelectInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Renderer sphereRenderer;
    private Material originalMaterial;
    public Material blueMaterial;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        sphereRenderer = GetComponent<Renderer>();
        originalMaterial = sphereRenderer.material;

        grabInteractable.selectEntered.AddListener(OnSelectEnter);
        grabInteractable.selectExited.AddListener(OnSelectExit);
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        sphereRenderer.material = blueMaterial;

        // Check if the selecting interactor has haptics.
        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            controllerInteractor.SendHapticImpulse(0.5f, 0.2f);
        }
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        sphereRenderer.material = originalMaterial;
    }
}