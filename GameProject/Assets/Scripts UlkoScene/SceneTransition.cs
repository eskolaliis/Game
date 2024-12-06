using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // Linkitä Canvasissa oleva musta UI-kuva
    public float fadeDuration = 1f; // Fade-animaation kesto

    private void Start()
    {
        // Aloita fade-in, kun Scene käynnistyy
        StartCoroutine(FadeIn());
    }

    public void TriggerFadeOutAndLoad(string sceneName)
    {
        // Käynnistä FadeOut ja lataa Scene sen jälkeen
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        fadeImage.enabled = true; // Näytä kuva
        Color color = fadeImage.color;
        color.a = 1f; // Täysin musta alussa
        fadeImage.color = color;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1 - (timer / fadeDuration); // Laske alpha-arvoa
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0f; // Läpinäkyvä lopussa
        fadeImage.color = color;
        fadeImage.enabled = false; // Piilota kuva
    }

    private IEnumerator FadeOut(string sceneName)
    {
        fadeImage.enabled = true; // Näytä kuva
        Color color = fadeImage.color;
        color.a = 0f; // Aloita täysin läpinäkyvästä
        fadeImage.color = color;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // Lisää alpha-arvoa
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f; // Täysin musta lopussa
        fadeImage.color = color;

        // Lataa seuraava Scene FadeOutin jälkeen
        SceneManager.LoadScene(sceneName);
    }
}
