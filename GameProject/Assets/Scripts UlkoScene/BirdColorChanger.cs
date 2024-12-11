using UnityEngine;

public class BirdColorChanger : MonoBehaviour
{
    public Material blackMaterial; // Viittaus mustaan materiaaliin (crowMaterial)

    private Renderer birdRenderer;

    private void Start()
    {
        birdRenderer = GetComponentInChildren<Renderer>(); // Etsitään lintuun liittyvä Renderer

        if (birdRenderer != null && blackMaterial != null)
        {
            birdRenderer.material = blackMaterial; // Vaihdetaan materiaali mustaksi
            Debug.Log("Linnun materiaali vaihdettu mustaksi!");
        }
        else
        {
            Debug.LogWarning("Renderer tai musta materiaali puuttuu.");
        }
    }
}
