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
    // Tarkista, onko esine jo inventaariossa
    foreach (var item in inventoryItems)
    {
        if (item.name == itemName)
        {
            Debug.LogWarning($"Esine '{itemName}' on jo inventaariossa, ei lisätä uudelleen.");
            return; // Lopeta, jos esine löytyy jo
        }
    }

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

    // Palauta kaikki inventaarion esineet
    public List<InventoryItem> GetInventoryItems()
    {
        return inventoryItems;
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

    // Tarkista, onko tietty esine nimeltä löytynyt (esim. avain)
    public bool OnkoAvainLöytynyt(string avainNimi)
    {
        return inventoryItems.Exists(item => item.name == avainNimi);
    }

    // Debug-metodi inventaarion tilan tarkistamiseksi
    public void DebugInventory()
    {
        Debug.Log("Inventaarion tilan tarkistus:");
        foreach (var item in inventoryItems)
        {
            Debug.Log($"Esine: {item.name}");
        }
    }

    // Sisäinen InventoryItem-luokka
    public class InventoryItem
    {
        public string name; // Esineen nimi
        public Sprite icon; // Esineen kuvake
    }
}
