using UnityEngine;

public class CollectibleItem2D : MonoBehaviour
{
    public string itemName; // Esineen nimi
    public Sprite itemIcon; // Esineen kuvake

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Vasen hiiren klikkaus
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log($"Klikattiin esinettä: {itemName}");

                // Hae InventoryManager
                InventoryManager inventory = Object.FindFirstObjectByType<InventoryManager>();
                if (inventory != null)
                {
                    // Lisää esine inventaarioon
                    inventory.AddItem(itemName, itemIcon);

                    // Poista esine pelimaailmasta
                    Destroy(gameObject);
                }
            }
        }
    }
}
