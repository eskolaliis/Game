using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public string requiredItemName = "Avain"; // Esineen nimi, jolla ovi avataan
    public string nextSceneName; // Seuraavan Scenen nimi

    private void OnTriggerEnter(Collider other)
    {
        // Tarkista, osuuko pelaaja oveen
        if (other.CompareTag("Player"))
        {
            InventoryManager inventory = Object.FindFirstObjectByType<InventoryManager>();

            // Tarkista, onko esine inventaariossa
            if (inventory != null && inventory.HasItem(requiredItemName))
            {
                Debug.Log($"Ovi avautuu, koska {requiredItemName} löytyy inventaariosta!");
                LoadNextScene();
            }
            else
            {
                Debug.Log("Ovi on lukossa. Tarvitset avaimen!");
            }
        }
    }

    private void LoadNextScene()
    {
        // Lataa seuraava Scene
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Seuraavan Scenen nimeä ei ole asetettu!");
        }
    }
}
