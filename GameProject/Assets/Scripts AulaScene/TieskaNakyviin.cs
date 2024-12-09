using UnityEngine;

public class TieskaNakyviin : MonoBehaviour
{
    public GameObject TieskaPlace;
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown kutsuttiin!");



        // Aktivoi objekti
        if (TieskaPlace != null)
        {
            TieskaPlace.SetActive(true);
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
