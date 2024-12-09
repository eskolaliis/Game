using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public bool isPuzzleActive = false; // Onko palapeli aktivoitu?

    public void ActivatePuzzle()
    {
        isPuzzleActive = true;
        Debug.Log("Palapeli aktivoitu! Pelaaja voi aloittaa ratkaisun.");
        // Tähän voit lisätä logiikkaa, joka näyttää palapelin tai aktivoi sen osat.
    }
}
