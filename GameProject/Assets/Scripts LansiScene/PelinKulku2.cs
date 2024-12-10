using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PelinKulku2 : MonoBehaviour
{
    public GameObject OpenTeksti;
    public GameObject HarhautusTeksti;
    public GameObject EiOnnistu;
    public GameObject VihjeTeksti;
    public GameObject ItemPlace;
    public GameObject Nuoli;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    public void VihjeNappula()
    {
        OpenTeksti.SetActive(false);
        VihjeTeksti.SetActive(true);

        // Kutsuu funktiota 5 sekunnin kuluttua
        Invoke("PalautaOpenTeksti", 5f);
    }

    private void PalautaOpenTeksti()
    {
        VihjeTeksti.SetActive(false);
        EiOnnistu.SetActive(false);
        OpenTeksti.SetActive(true);
    }

    void OnMouseDown()
    {
        if (!ItemPlace.activeInHierarchy) // Jos ItemPlace ei ole aktiivinen hierarkiassa
        {
            OpenTeksti.SetActive(false);
            EiOnnistu.SetActive(true);

            // Kutsuu funktiota 5 sekunnin kuluttua
            Invoke("PalautaOpenTeksti", 5f);
        }

        else
        {
            OpenTeksti.SetActive(false);
            HarhautusTeksti.SetActive(true);
            Nuoli.SetActive(true);
        }
    }




    void Update()
    {

    }
}
