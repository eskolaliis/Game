using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // UI-paneeli
    public Transform itemParent; // Inventaarion esineiden sijoituspaikka UI:ssa
    public GameObject inventoryItemPrefab; // Prefab esineen esittämiseksi UI:ssa

    private List<CollectibleItem> inventoryList = new List<CollectibleItem>();

    public void AddItem(CollectibleItem item)
    {
        // Lisää esine listaan
        inventoryList.Add(item);

        // Päivitä UI
        GameObject newItem = Instantiate(inventoryItemPrefab, itemParent);
        newItem.GetComponentInChildren<Text>().text = item.itemName; // Esineen nimi
        newItem.GetComponent<Image>().sprite = item.itemIcon; // Esineen kuvake
    }
}
