using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateSkybox : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Skyboxin pyörityksen nopeus

    void Update()
    {
        // Tarkista, että aktiivinen Scene on "MainMenu"
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            // Pyöritä Skyboxia
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
        }
    }
}
