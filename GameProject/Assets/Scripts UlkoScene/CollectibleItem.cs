using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string itemName; // Esineen nimi
    public Sprite itemIcon; // Esineen kuvake (inventaarioon)

    void OnMouseDown()
    {
        // Etsi InventoryManager
        InventoryManager inventory = Object.FindFirstObjectByType<InventoryManager>();
        if (inventory != null)
        {
            // Lisää esine inventaarioon
            inventory.AddItem(this);

            // Poista esine maailmasta
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("InventoryManager ei löydy!");
        }
    }
}
