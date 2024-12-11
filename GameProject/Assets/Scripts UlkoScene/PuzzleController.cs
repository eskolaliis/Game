using UnityEngine;
using TMPro;

public class PuzzleController : MonoBehaviour
{
    public TMP_InputField answerInputField; // Viittaus tekstikenttään
    public TextMeshProUGUI hintText; // Viittaus vihjetekstiin
    public GameObject puzzleUI; // Viittaus koko PuzzleUI-elementtiin (sisältää tekstikentän ja napin)
    public string correctAnswer = "avain"; // Oikea vastaus

    public Sprite toolIcon; // Työkalun kuvake

    private bool puzzleSolved = false; // Estää työkalun uudelleen antamisen

    public void CheckAnswer()
    {
        string playerAnswer = answerInputField.text.ToLower(); // Pelaajan vastaus pienellä kirjaimilla
        if (playerAnswer == correctAnswer && !puzzleSolved)
        {
            hintText.text = "Oikein! Tässä on palkintosi.";
            Debug.Log("Pelaaja vastasi oikein!");
            puzzleSolved = true; // Merkitään tehtävä ratkaistuksi
            HidePuzzleUI(); // Kutsu piilota UI ja anna työkalu
        }
        else
        {
            hintText.text = "Väärin! Yritä uudelleen.";
            Debug.Log("Pelaaja vastasi väärin.");
        }
    }

    private void HidePuzzleUI()
    {
        hintText.text = ""; // Tyhjennä vihjeteksti
        puzzleUI.SetActive(false); // Piilota koko PuzzleUI

        // Lisää työkalu inventaarioon vain, jos tehtävä on ratkaistu
        if (puzzleSolved)
        {
            InventoryManager inventory = Object.FindFirstObjectByType<InventoryManager>();
            if (inventory != null && toolIcon != null)
            {
                inventory.AddItem("Työkalu", toolIcon); // Lisää työkalu inventaarioon kuvakkeen kanssa
                Debug.Log("Työkalu lisätty inventaarioon!");
            }
            else
            {
                Debug.LogWarning("Inventaario tai työkalun kuvake puuttuu!");
            }
        }
    }
}
