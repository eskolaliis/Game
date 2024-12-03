using UnityEngine;

public class AvaaInventory : MonoBehaviour
{
    // Viittaus InventoryPaneliin
    public GameObject inventoryPanel;

    void Start()
    {
        // Varmista, että InventoryPanel on piilossa alussa
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    // Kun roskista klikataan
    void OnMouseDown()
    {
        if (inventoryPanel != null)
        {
            // Näytä tai piilota paneeli
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);
        }
    }
}
