using UnityEngine;

public class VoittoIkkuna : MonoBehaviour
{
    public GameObject VoittoTeksti; // voittoteksti
    public GameObject VoittoTausta; // 3D tekstien taustaobjekti
    public AudioSource hurrayAani; // AudioSource hurray- ‰‰nille
    public bool voitto = false;
    public void Start()
    {
        // alussa voittoikkuna on piilotettu
        if (VoittoTeksti != null && VoittoTausta != null)
        {
            VoittoTeksti.SetActive(false);
            VoittoTausta.SetActive(false);
        }
    }
    public void OnMouseDown()
    {
        if (!voitto) // est‰‰ useita aktivointeja
        {
            voitto = true;

            // n‰ytt‰‰ voittoikkuna
            if (VoittoTeksti != null)
            {
                VoittoTeksti.SetActive(true);
                VoittoTausta.SetActive(true);
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