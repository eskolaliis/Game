using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Esineiden lista
    private List<string> collectedItems = new List<string>();

    // UI-paneeli inventaariolle
    public Transform inventoryPanel;

    // Prefab yksittäiselle esineelle inventaariossa
    public GameObject inventoryItemPrefab;

    public void AddItem(string itemName, Sprite itemIcon)
    {
        // Lisää esine listaan
        collectedItems.Add(itemName);

        // Luo uusi UI-elementti inventaariopaneeliin
    
        GameObject newItem = Instantiate(inventoryItemPrefab, inventoryPanel.transform);
        Image itemImage = newItem.GetComponentInChildren<Image>();
        if (itemImage != null)
        {
            itemImage.sprite = itemIcon; // Tämä asettaa esineen kuvakkeen
        }


        // Aseta kuvake ja nimi
        if (itemImage != null)
        {
            itemImage.sprite = itemIcon;
        }

        Debug.Log($"Esine lisätty inventaarioon: {itemName}");
    }
}
