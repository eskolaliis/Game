using UnityEngine;

public class VoittoIkkuna : MonoBehaviour
{
    public GameObject Canvas1; // voittoteksti ja voittoikkuna
    public AudioSource hurrayAani; // AudioSource hurray- ‰‰nille
    public bool voitto = false;
    public void Start()
    {
        // alussa voittoikkuna on piilotettu
        if (Canvas1 != null)
        {
            Canvas1.SetActive(false);
        }
    }
    public void OnMouseDown()
    {
        if (!voitto) // est‰‰ useita aktivointeja
        {
            voitto = true;

            // n‰ytt‰‰ voittoikkuna
            if (Canvas1 != null)
            {
                Canvas1.SetActive(true);
            }

            // soittaa hurray- ‰‰nt‰
            if (hurrayAani != null)
            {
                hurrayAani.Play();
            }

            Debug.Log("Pelaaja voitti pelin!");
        }
    }
}