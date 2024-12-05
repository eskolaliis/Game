using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D hoverCursor; // Kuvake, joka näkyy, kun hiiri on objektin päällä
    public Texture2D defaultCursor; // Oletuskursorin kuvake

    private void OnMouseEnter()
    {
        // Vaihda kursorin kuva hover-tilaan
        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        // Palauta oletuskursori
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
