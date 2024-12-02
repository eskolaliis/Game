using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Pyörityksen nopeus

    void Update()
    
    {
        // Asettaa Skyboxin pyörimään jatkuvasti ajan mukaan
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}



