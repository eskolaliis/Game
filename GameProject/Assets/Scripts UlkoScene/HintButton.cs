using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintButton : MonoBehaviour
{
    public TextMeshProUGUI hintText; 
    public string avaimenNimi = "Avain"; // Nimi inventaarion avaimelle
    private InventoryManager inventoryManager;

    private void Start()
    {
        // Hae InventoryManager
        inventoryManager = Object.FindFirstObjectByType<InventoryManager>();
    }

    public void OnHintButtonClicked()
    {
        if (inventoryManager != null)
        {
            if (inventoryManager.OnkoAvainLöytynyt(avaimenNimi))
            {
                // Jos avain on löydetty
                ShowHint("Kokeile pääsetkö sisälle.");
            }
            else
            {
                // Jos avain ei ole löydetty
                ShowHint("Etsi avain roskiksesta.");
            }
        }
    }

    private void ShowHint(string message)
    {
        if (hintText != null)
        {
            hintText.text = message; // Aseta teksti
            hintText.enabled = true; // Näytä teksti
            Invoke("HideHint", 5f); // Piilota teksti 5 sekunnin jälkeen
        }
    }

    private void HideHint()
    {
        if (hintText != null)
        {
            hintText.enabled = false; // Piilota teksti
        }
    }
}
