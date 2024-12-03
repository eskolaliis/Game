using UnityEngine;

public class RoskisInteraction : MonoBehaviour
{
    public GameObject inventoryPanel; // Tämä on ruutu, joka avautuu

    void OnMouseDown()
    {
        // Tarkista, että ruutu on asetettu ja näytä se
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Inventory Panel is not assigned!");
        }
    }
}
