using UnityEngine;

public class CollectKey : MonoBehaviour
{
    public string keyName = "Avain1"; // Avain1 nimi
    public Sprite keyIcon; // Kuvake inventaariota varten

    private void OnMouseDown()
    {
        InventoryManager inventory = Object.FindFirstObjectByType<InventoryManager>();
        if (inventory != null)
        {
            inventory.AddItem(keyName, keyIcon); // Lisää avain inventaarioon
            Debug.Log($"Keräsit avaimen: {keyName}");
            Destroy(gameObject); // Poista avain pelistä
        }
    }
}