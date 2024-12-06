using System.Collections; // Lisää tämä!
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

    public void LoadScene(string sceneName)
    {
        // Aloita fade-out ja vaihda Scene
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        fadeImage.enabled = true; // Varmista, että kuva on näkyvissä
        float timer = fadeDuration;
        Color color = fadeImage.color;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            color.a = timer / fadeDuration; // Vähennä alpha-arvoa
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.enabled = false; // Piilota kuva fade-inin jälkeen
    }

    private IEnumerator FadeOut(string sceneName)
    {
        fadeImage.enabled = true; // Näytä kuva
        float timer = 0f;
        Color color = fadeImage.color;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // Lisää alpha-arvoa
            fadeImage.color = color;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
