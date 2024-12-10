using UnityEngine;
using TMPro;

public class PuzzleController : MonoBehaviour
{
    public TMP_InputField answerInputField; // Viittaus tekstikenttään
    public TextMeshProUGUI hintText; // Viittaus vihjetekstiin
    public string correctAnswer = "avain"; // Oikea vastaus

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
    }
}
