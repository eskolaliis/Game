using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public AudioSource audioSource; // Linkitetään AudioSource
    public string itemName = "Avain"; // Inventaarion nimi

    private void OnMouseDown()
    {
        Debug.Log($"Klikattiin esinettä: {itemName}");

        if (audioSource != null)
        {
            Debug.Log("Soitetaan avaimen ääni.");
            audioSource.Play(); // Soitetaan ääni
        }
        else
        {
            Debug.LogWarning("AudioSource ei ole määritetty!");
        }
    }
}
