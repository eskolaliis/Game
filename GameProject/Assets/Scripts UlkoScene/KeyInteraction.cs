using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        if (audioSource != null)
        {
            Debug.Log("Soitetaan avaimen ääni.");
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Audio Source ei ole määritetty!");
        }
    }
}
