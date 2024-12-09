using UnityEngine;
using UnityEngine.UI;

public class MemoryTile : MonoBehaviour
{
    public Sprite frontImage; // Etupuolen kuva
    public Sprite backImage; // Takapuolen kuva
    private Image tileImage; // Laatan Image-komponentti

    private bool isRevealed = false; // Onko laatta paljastettu
    private MemoryPuzzleManager puzzleManager; // Viittaus manageriin

    void Start()
    {
        tileImage = GetComponent<Image>();
        tileImage.sprite = backImage; // Näytetään aluksi takapuoli
        puzzleManager = Object.FindFirstObjectByType<MemoryPuzzleManager>(); // Löydetään manageri
    }

    public void OnTileClicked()
    {
        if (isRevealed || puzzleManager.IsCheckingTiles) return; // Estetään ylimääräiset klikkaukset

        isRevealed = true;
        tileImage.sprite = frontImage; // Paljasta laatta
        puzzleManager.TileRevealed(this); // Ilmoita managerille
    }

    public void HideTile()
    {
        isRevealed = false;
        tileImage.sprite = backImage; // Palauta takapuoli
    }

    public bool IsMatching(MemoryTile otherTile)
    {
        return this.frontImage == otherTile.frontImage; // Vertaa etupuolen kuvia
    }
}
