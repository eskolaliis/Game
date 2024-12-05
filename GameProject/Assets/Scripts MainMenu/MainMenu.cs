using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Vaihda tämä Scenen nimi siihen mistä peli alkaa
        SceneManager.LoadScene("UlkoScene");
    }

    public void QuitGame()
    {
        // Lopettaa pelin (toimii buildatussa versiossa)
        Application.Quit();
        Debug.Log("Game is exiting...");
    }
}
