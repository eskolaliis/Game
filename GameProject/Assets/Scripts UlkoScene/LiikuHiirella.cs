
using UnityEngine;

public class LiikuHiirella : MonoBehaviour
{
    public float rotationSpeed = 0.2f; // Määrittää kuinka nopeasti kamera pyörii
    private bool isDragging = false;  // Tarkistaa, onko hiiren painike painettuna
    private Vector3 lastMousePosition; // Tallentaa viimeisimmän hiiren sijainnin

    void Update()
    {
        // Tarkista, onko hiiren vasen painike painettuna
        if (Input.GetMouseButtonDown(0)) // 0 = vasen hiiren painike
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        // Tarkista, onko hiiren painike vapautettu
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Jos pelaaja vetää hiirellä
        if (isDragging)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;

            // Pyöritä kameraa vaakasuunnassa (Y-akselilla)
            float rotationX = mouseDelta.x * rotationSpeed;

            // Pyöritä kameraa pystysuunnassa (X-akselilla)
            float rotationY = -mouseDelta.y * rotationSpeed;

            // Päivitä kameran rotaatio
            transform.Rotate(Vector3.up, rotationX, Space.World); // Y-akselin pyöritys
            transform.Rotate(Vector3.right, rotationY, Space.Self); // X-akselin pyöritys

            // Päivitä viimeisin hiiren sijainti
            lastMousePosition = Input.mousePosition;
        }
    }
}
