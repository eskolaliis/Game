using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorInteraction : MonoBehaviour
{
    public string requiredItemName = "Avain"; // Nimi inventaariossa olevasta avaimesta
    public string nextSceneName = "AulaScene"; // Seuraava Scene
    public SceneTransition sceneTransition; // Linkitä SceneTransition tähän Inspectorissa

    public TextMeshProUGUI lockMessage; // UI-tekstielementti
    public AudioSource doorOpenSound; // Ääni oven avaamiselle

    private void OnMouseDown()
    {
        InventoryManager inventory = FindFirstObjectByType<InventoryManager>();
        if (inventory != null && inventory.HasItem(requiredItemName))
        {
            Debug.Log($"Ovi avautuu, koska {requiredItemName} löytyy inventaariosta!");

            // Soita oven avautumisen ääni
            if (doorOpenSound != null)
            {
                Debug.Log("Oven ääni soitetaan!");
                doorOpenSound.Play();
            }
            else
            {
                Debug.LogWarning("Door Open Sound ei ole määritetty!");
            }


            // FadeOut ennen Scene-vaihtoa
            if (sceneTransition != null)
            {
                if (doorOpenSound != null)
                {
                    Invoke("TriggerFadeOutAndLoad", doorOpenSound.clip.length); // Viivästytä Scene-vaihtoa
                }
                else
                {
                    sceneTransition.TriggerFadeOutAndLoad(nextSceneName);
                }
            }
            else
            {
                // Jos SceneTransition ei ole määritetty, lataa seuraava Scene suoraan
                if (doorOpenSound != null)
                {
                    Invoke("LoadNextScene", doorOpenSound.clip.length); // Viivästytä Scene-vaihtoa
                }
                else
                {
                    LoadNextScene();
                }
            }
        }
        else
        {
            Debug.Log("Ovi on lukossa. Tarvitset avaimen!");
            ShowLockMessage("Ovi on lukossa! Tarvitset avaimen.");
        }
    }

    private void TriggerFadeOutAndLoad()
    {
        if (sceneTransition != null)
        {
            sceneTransition.TriggerFadeOutAndLoad(nextSceneName);
        }
    }

    private void LoadNextScene()
{
    if (!string.IsNullOrEmpty(nextSceneName))
    {
        // Odota äänen pituuden verran ennen Scene-vaihtoa
        if (doorOpenSound != null)
        {
            float soundDuration = doorOpenSound.clip.length; // Hae äänen pituus
            Invoke(nameof(LoadSceneDelayed), soundDuration); // Kutsu Scene-vaihto viiveellä
        }
        else
        {
            Debug.LogWarning("Door Open Sound ei ole määritetty! Ladataan Scene suoraan.");
            SceneManager.LoadScene(nextSceneName); // Jos ääntä ei ole, vaihda Scene heti
        }
    }
    else
    {
        Debug.LogError("Seuraavan Scenen nimeä ei ole asetettu!");
    }
}

// Scene-vaihdon viivästykseen käytettävä metodi
private void LoadSceneDelayed()
{
    SceneManager.LoadScene(nextSceneName);
}


    private void ShowLockMessage(string message)
    {
        if (lockMessage != null)
        {
            lockMessage.text = message; // Aseta viesti tekstielementtiin
            lockMessage.enabled = true; // Näytä teksti
            Invoke("HideLockMessage", 3f); // Piilota teksti 3 sekunnin jälkeen
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
