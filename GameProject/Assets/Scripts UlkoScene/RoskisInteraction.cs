using UnityEngine;

public class RoskisInteraction : MonoBehaviour
{
    public AudioSource audioSource; // Yleinen ääni roskiksen avaamiselle
    public AudioSource keyFoundAudioSource; // Ääni, kun avain löytyy
    public string requiredItemName = "Avain"; // Avain lisätään inventaarioon
    public InventoryManager inventoryManager; // Inventaariojärjestelmä

    private bool keyFound = false; // Varmistaa, että avain löytyy vain kerran

    private void OnMouseDown()
    {
        // Soita yleinen roskiksen avaamisääni
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Jos avain on jo löydetty, ei tehdä mitään
        if (keyFound)
        {
            return;
        }

        // Lisää avain inventaarioon, jos InventoryManager on määritetty
        if (inventoryManager != null)
        {
            inventoryManager.AddItem(requiredItemName, null); // Kuvake voidaan lisätä nullin sijaan
            keyFound = true; // Merkitään, että avain on löydetty

            // Soita ääni avaimen löytymisen yhteydessä
            if (keyFoundAudioSource != null)
            {
                keyFoundAudioSource.Play();
            }

            Debug.Log("Avain lisätty inventaarioon!");
        }
    }
}
