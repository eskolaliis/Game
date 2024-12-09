using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public AudioSource audioSource; // Audio Source komponentti
    public string itemName = "Avain"; // Nimi inventaariossa

    private void OnMouseDown()
    {
        Debug.Log("Klikattiin esinettä: Avain");

        // Tarkista ja aktivoi Audio Source, jos se on pois päältä
        if (audioSource != null)
        {
            if (!audioSource.enabled)
            {
                audioSource.enabled = true; // Aktivoi Audio Source
            }

            Debug.Log("Soitetaan avaimen ääni.");
            audioSource.Play(); // Soita ääni
        }
        else
        {
            Debug.LogWarning("Audio Source puuttuu!");
        }

        
    }
}
