using UnityEngine;

public class VoittoIkkuna : MonoBehaviour
{
    public GameObject CanvasVoitto; // voittoteksti ja voittoikkuna
    public AudioSource hurrayAani; // AudioSource hurray- ‰‰nille
    public GameObject Tietokone; // sprite objekti
    public GameObject ArvoitusPaneeli; // arvoituspaneeli
    public bool voitto = false;
    public void Start()
    {
        // alussa voittoikkuna on piilotettu
        if (CanvasVoitto != null)
        {
            CanvasVoitto.SetActive(false);
        }
    }
    public void OnMouseDown()
    {
        if (!voitto) // est‰‰ useita aktivointeja
        {
            voitto = true;

            // n‰ytt‰‰ voittoikkuna
            if (CanvasVoitto != null)
            {
                CanvasVoitto.SetActive(true);
                Tietokone.SetActive(false);
                ArvoitusPaneeli.SetActive(false);
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
