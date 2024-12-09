using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PekkaInt : MonoBehaviour
{
    public string requiredItemName = "Kuvat"; // Nimi inventaariossa olevasta avaimesta
    public string nextSceneName = "ITopetScene"; // Seuraava Scene
    public SceneTransition sceneTransition; // Linkitä SceneTransition tähän Inspectorissa


    public TextMeshProUGUI lockMessage; // UI-tekstielementti
    // Jos käytät TextMeshPro:ta, käytä: public TextMeshProUGUI lockMessage;

private void OnMouseDown()
{
    InventoryManager inventory = FindFirstObjectByType<InventoryManager>();
    if (inventory != null && inventory.HasItem(requiredItemName))
    {
        Debug.Log($"Ovi avautuu, koska {requiredItemName} löytyy inventaariosta!");

        // FadeOut ennen Scene-vaihtoa
        if (sceneTransition != null)
        {
            sceneTransition.TriggerFadeOutAndLoad(nextSceneName);
        }
        else
        {
            // Jos SceneTransition ei ole määritetty, lataa seuraava Scene suoraan
            LoadNextScene();
        }
    }
    else
    {
        Debug.Log("Pekka on edessä, tarvitset harhautuksen!");
        ShowLockMessage("Pekka on edessä, tarvitset harhautuksen!");
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

    private void ShowLockMessage(string message)
    {
        if (lockMessage != null)
        {
            lockMessage.text = message; // Aseta viesti tekstielementtiin
            lockMessage.enabled = true; // Näytä teksti
            Invoke("HideLockMessage", 5f); // Piilota teksti 5 sekunnin jälkeen
        }
    }

    private void HideLockMessage()
    {
        if (lockMessage != null)
        {
            lockMessage.enabled = false; // Piilota teksti
        }
    }
}
