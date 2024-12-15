using UnityEngine;
using System.Collections.Generic;

public class BinScript : MonoBehaviour
{
    public Material defaultMaterial;
    public Material successMaterial;
    public List<GameObject> binSides;
    
    void Start()
    {
        SetWallsMaterial(defaultMaterial);
    }

    // This method sets the material for all bin sides in the provided list
    public void SetWallsMaterial(Material material)
    {
        foreach (GameObject side in binSides)
        {
            Renderer sideRenderer = side.GetComponent<Renderer>();
            if (sideRenderer != null)
            {
                sideRenderer.material = material;
            }
            else
            {
                Debug.LogWarning("Side object does not have a Renderer component: " + side.name);
            }
        }
    }

    public void OnObjectEntered(bool isSuccess)
    {
        if (isSuccess)
        {
            SetWallsMaterial(successMaterial);
        }
        else
        {
            SetWallsMaterial(defaultMaterial);
        }
    }
}