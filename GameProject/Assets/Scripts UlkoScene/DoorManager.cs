using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public bool isDoorOpen = false; // Ovi on aluksi kiinni

    public void TryOpenDoor()
    {
        if (isDoorOpen)
        {
            Debug.Log("Ovi on jo auki!");
            return;
        }

        Debug.Log("Ovi avautuu!");
        isDoorOpen = true;
        // Lisää logiikka oven avaamiseen, kuten animaation soittaminen tai oven siirtäminen
    }
}
