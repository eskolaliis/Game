using UnityEngine;

public class TonttuNakyviin : MonoBehaviour
{
    public GameObject TonttuPlace;
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown kutsuttiin!");



        // Aktivoi objekti
        if (TonttuPlace != null)
        {
            TonttuPlace.SetActive(true);
            Debug.Log("ItemPlace asetettiin n‰kyv‰ksi.");
        }
        else
        {
            Debug.LogError("ItemPlace-objekti ei ole m‰‰ritetty!");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
