using UnityEngine;
using TMPro;

public class QuestionAnswer3D : MonoBehaviour
{
    [SerializeField] public GameObject Books; // sprite objekti
    [SerializeField] public TextMeshPro arvoitusTeksti; // 3D arvoitusteksti
    [SerializeField] public TMP_InputField vastausKentta; // 3D syöttökenttä pelaajan vastaukselle
    [SerializeField] public TextMeshPro tulosTeksti; // 3D tulosteksti
    [SerializeField] public GameObject vastausPainike; // 3D tarkistapainike
    [SerializeField] public GameObject Tausta; // 3D tekstien taustaobjekti
    [SerializeField] public string oikeaVastaus = "1"; // oikea vastaus kysymykseen
    [SerializeField] public string kysymys = "Matemaattinen arvoitus:\nJos 1=5, 2=6, 3=7, 4=8, 5=? "; // arvoitus kysymys

    public bool kysymysActive = false;

    public void Start()
    {
        // piilota aluksi kaikki elementit ja tausta
        arvoitusTeksti.gameObject.SetActive(false);
        vastausKentta.gameObject.SetActive(false);
        tulosTeksti.gameObject.SetActive(false);
        vastausPainike.SetActive(false);
        Tausta.SetActive(false);

    }

    public void OnMouseDown()
    {
        Debug.Log("Sprite napsautettiin!"); // Log vahvistus, että napsautus on havaittu

        if (!kysymysActive && Books != null && Books.activeSelf)
        {
            Debug.Log("Näytetään arvoitus, syöttökenttä, painike ja tausta."); // Log arvoituksen aktivointia varten

            // näyttää arvoitus, syöttökenttä, painike ja tausta
            arvoitusTeksti.gameObject.SetActive(true);
            vastausKentta.gameObject.SetActive(true);
            vastausPainike.SetActive(true);
            Tausta.SetActive(true);

            // asettaa arvoituksen teksti
            arvoitusTeksti.text = kysymys;
            kysymysActive = true;
        }
        else
        {
            Debug.LogWarning("Sprite-napsautus ohitettu: arvoitus on jo aktiivinen tai spritea ei ole asetettu.");
        }
    }

    public void CheckAnswer()
    {
        string pelaajanVastaus = vastausKentta.text;

        if (string.Equals(pelaajanVastaus, oikeaVastaus, System.StringComparison.OrdinalIgnoreCase))
        {
            tulosTeksti.text = "Annoit oikean vastauksen!\nPalohälytys laukeaa. Kaikki opettajat poistuvat opehuoneesta. Nyt etsi Yrjön tietokone.";
            // kun oikea vastaus annettu, piilota arvoitusteksti, syöttökenttä, vastauspainike ja tausta
            arvoitusTeksti.gameObject.SetActive(false);
            vastausKentta.gameObject.SetActive(false);
            vastausPainike.SetActive(false);
            Tausta.SetActive(true); 
        }
        else
        {
            // kun väärä vastaus annettu, piilota arvoitusteksti ja edelleen näytä syöttökenttä, vastauspainike ja tausta
            tulosTeksti.text = "Yritä uudelleen!\n\nMatemaattinen arvoitus:\nJos 1=5, 2=6, 3=7, 4=8, 5=?";
            arvoitusTeksti.gameObject.SetActive(false);
            Tausta.SetActive(true);
        }

        tulosTeksti.gameObject.SetActive(true); // näytä tulosteksti
    }

    public void HideQuestionUI()
    {
        // Piilota kaikki arvoitukeen liittyvät elementit ja tausta
        arvoitusTeksti.gameObject.SetActive(false);
        vastausKentta.gameObject.SetActive(false);
        vastausPainike.SetActive(false);
        Tausta.SetActive(false);
    }
}
