using UnityEngine;
using TMPro;

public class RoskisInteraction : MonoBehaviour
{
    public AudioSource audioSource; // Yleinen ääni roskiksen avaamiselle
    public AudioSource keyFoundAudioSource; // Ääni, kun avain löytyy
    public string requiredItemName = "Avain"; // Avain lisätään inventaarioon
    public string requiredToolName = "Työkalu"; // Työkalu roskiksen avaamiseen
    public InventoryManager inventoryManager; // Inventaariojärjestelmä
    public TextMeshProUGUI messageText; // Teksti, joka näyttää viestin pelaajalle
    public GameObject inventoryPanel; // Paneeli, joka näyttää roskiksen sisältämät esineet

    private bool keyFound = false; // Varmistaa, että avain löytyy vain kerran
    private bool trashCanOpened = false; // Varmistaa, että roskis avataan vain kerran

    private void Start()
    {
        // Varmista, että inventaariopaneeli on piilotettu alussa
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

private void OnMouseDown()
{
    // Debug-lokit inventaarion tarkistamiseen
    if (inventoryManager != null)
    {
        Debug.Log("Tarkistetaan inventaario...");
        Debug.Log("Inventaarion sisältö:");
        foreach (var item in inventoryManager.GetInventoryItems())
        {
            Debug.Log("Esine: " + item.name);
        }
    }

    // Jos roskis on jo avattu, ei tehdä mitään
    if (trashCanOpened)
    {
        Debug.Log("Roskis on jo avattu.");
        return;
    }

    // Debug-tarkistukset inventaarion tilasta
    if (inventoryManager != null)
    {
        Debug.Log("Tarkistetaan inventaarion sisältö...");
        foreach (var item in inventoryManager.GetInventoryItems())
        {
            Debug.Log("Inventaarion esine: " + item.name);
        }

        Debug.Log("Vaadittu työkalu: " + requiredToolName);
    }
    else
    {
        Debug.LogError("InventoryManager ei ole asetettu!");
    }

    // Tarkista, onko pelaajalla oikea työkalu
    if (inventoryManager != null && inventoryManager.HasItem(requiredToolName))
    {
        Debug.Log("Roskis avattu työkalulla!");
        trashCanOpened = true; // Merkitään, että roskis on avattu

        // Näytä inventaariopaneeli
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(true);
        }

        // Soita yleinen roskiksen avaamisääni
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Näytä avain (tai muu esine), mutta älä lisää inventaarioon
        if (!keyFound)
        {
            GameObject avain = GameObject.Find("Avain"); // Korvaa "Avain" oikealla GameObject-nimellä
            if (avain != null)
            {
                avain.SetActive(true); // Tee avain näkyväksi
                Debug.Log("Avain näkyvillä, mutta ei lisätty inventaarioon.");
            }
            else
            {
                Debug.LogWarning("Avain-objektia ei löytynyt!");
            }
        }
    }
    else
    {
        // Näytä viesti, että työkalu puuttuu
        if (messageText != null)
        {
            messageText.text = "Roskis on jumissa! Tarvitset työkalun.";
            Debug.Log("Et voi avata roskista ilman oikeaa työkalua!");
            Invoke(nameof(ClearMessage), 5f); // Poistaa viestin 5 sekunnin kuluttua
        }
    }
}





    private void ClearMessage()
    {
        if (messageText != null)
        {
            messageText.text = ""; // Tyhjennä viesti
        }
    }
}
