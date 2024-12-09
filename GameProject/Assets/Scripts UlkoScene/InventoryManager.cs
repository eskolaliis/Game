using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventoryManager : MonoBehaviour


{
    // Esineiden lista
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();

    // UI-paneeli inventaariolle
    public Transform inventoryPanel;

    // Prefab yksittäiselle esineelle inventaariossa
    public GameObject inventoryItemPrefab;

    

    // Esineen lisääminen inventaarioon
    public void AddItem(string itemName, Sprite itemIcon)
    {
        // Luo uusi InventoryItem ja lisää se listaan
        InventoryItem newItem = new InventoryItem { name = itemName, icon = itemIcon };
        inventoryItems.Add(newItem);

        // Luo uusi UI-elementti inventaariopaneeliin
        GameObject newItemUI = Instantiate(inventoryItemPrefab, inventoryPanel.transform);
        Image itemImage = newItemUI.GetComponentInChildren<Image>();
        if (itemImage != null)
        {
            itemImage.sprite = itemIcon; // Aseta esineen kuvake
        }

        Debug.Log($"Esine lisätty inventaarioon: {itemName}");
    }

    // Tarkista, onko esine inventaariossa
    public bool HasItem(string itemName)
    {
        foreach (InventoryItem item in inventoryItems)
        {
            if (item.name == itemName)
            {
                return true; // Esine löytyi
            }
        }
        return false; // Esinettä ei löytynyt
    }

    // Sisäinen InventoryItem-luokka
    public class InventoryItem
    {
        public string name; // Esineen nimi
        public Sprite icon; // Esineen kuvake
    }

    // Esineen poistaminen inventaariosta
public void RemoveItem(string itemName)
{
    InventoryItem itemToRemove = inventoryItems.Find(item => item.name == itemName);
    if (itemToRemove != null)
    {
        inventoryItems.Remove(itemToRemove);
        Debug.Log($"Esine poistettu inventaariosta: {itemName}");
    }
}

public bool OnkoAvainLöytynyt(string avainNimi)
{
    return inventoryItems.Exists(item => item.name == avainNimi);
}


    
}
