using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public string requiredItemName = "Avain"; // Nimi inventaariossa olevasta avaimesta
    public string nextSceneName = "AulaScene"; // Seuraava Scene

    private void OnMouseDown()
    {
        // Tarkistetaan inventaario
        InventoryManager inventory = FindFirstObjectByType<InventoryManager>();
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



    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Seuraavan Scenen nimeä ei ole asetettu!");
        }
    }
}
