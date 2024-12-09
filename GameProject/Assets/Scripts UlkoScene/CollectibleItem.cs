using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string itemName; // Esineen nimi
    public Sprite itemIcon; // Esineen kuvake

    // Linkitetään InventoryManager Inspectorista
    public InventoryManager inventoryManager;

    void OnMouseDown()
{
    Debug.Log($"Klikattiin esinettä: {itemName}");

    // InventoryManager hakeminen
    InventoryManager inventory = Object.FindFirstObjectByType<InventoryManager>();


    if (inventory != null)
    {
        Debug.Log("InventoryManager löytyi!");

        // Lisää esine inventaarioon
        inventory.AddItem(itemName, itemIcon);

        // Esineen tuhoaminen
        Destroy(gameObject);
    }
    else
    {
        Debug.LogError("InventoryManager ei löytynyt!");
    }
}

    void OnMouseOver()
{
    Debug.Log($"Hiiri on objektin {itemName} päällä.");
}

    
}

