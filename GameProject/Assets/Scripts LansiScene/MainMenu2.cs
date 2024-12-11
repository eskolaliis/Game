using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    public void StartGame()
    {
        // Vaihda tämä Scenen nimi siihen mistä peli alkaa
        SceneManager.LoadScene("ITopetScene");
    }


}
