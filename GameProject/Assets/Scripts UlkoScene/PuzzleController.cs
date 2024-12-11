using UnityEngine;
using TMPro;

public class PuzzleController : MonoBehaviour
{
    public TMP_InputField answerInputField; // Viittaus tekstikenttään
    public TextMeshProUGUI hintText; // Viittaus vihjetekstiin
    public GameObject puzzleUI; // Viittaus koko PuzzleUI-elementtiin (sisältää tekstikentän ja napin)
    public string correctAnswer = "avain"; // Oikea vastaus

    public Sprite toolIcon; // Työkalun kuvake

    public void CheckAnswer()
    {
        string playerAnswer = answerInputField.text.ToLower(); // Pelaajan vastaus pienellä
        if (playerAnswer == correctAnswer)
        {
            hintText.text = "Oikein! Tässä on palkintosi.";
            Debug.Log("Pelaaja vastasi oikein!");
            // Voit lisätä logiikkaa työkalun antamiseen
        }
        else
        {
            hintText.text = "Väärin! Yritä uudelleen.";
            Debug.Log("Pelaaja vastasi väärin.");
        }

        // Piilota PuzzleUI ja vihjeteksti 5 sekunnin kuluttua
        Invoke("HidePuzzleUI", 5f);
    }

    private void HidePuzzleUI()
    {
        hintText.text = ""; // Tyhjennä vihjeteksti
        puzzleUI.SetActive(false); // Piilota koko PuzzleUI

        // Lisää työkalu inventaarioon
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