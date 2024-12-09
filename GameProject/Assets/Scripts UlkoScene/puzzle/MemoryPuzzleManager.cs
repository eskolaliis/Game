using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPuzzleManager : MonoBehaviour
{
    public List<MemoryTile> tiles; // Lista kaikista laatoista
    private MemoryTile firstRevealedTile; // Ensimmäinen käännetty laatta
    private MemoryTile secondRevealedTile; // Toinen käännetty laatta

    public bool IsCheckingTiles { get; private set; } = false; // Estää ylimääräiset klikkaukset tarkistuksen aikana

    private int pairsFound = 0; // Löydettyjen parien määrä

    public void TileRevealed(MemoryTile revealedTile)
    {
        // Jos tämä on ensimmäinen laatta, aseta se firstRevealedTileksi
        if (firstRevealedTile == null)
        {
            firstRevealedTile = revealedTile;
        }
        else
        {
            // Jos tämä on toinen laatta, aseta se secondRevealedTileksi ja tarkista pari
            secondRevealedTile = revealedTile;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        IsCheckingTiles = true; // Estetään ylimääräiset klikkaukset tarkistuksen aikana

        yield return new WaitForSeconds(1f); // Odotetaan hetki ennen tarkistusta

        if (firstRevealedTile.IsMatching(secondRevealedTile))
        {
            Debug.Log("Pari löytyi!");
            pairsFound++;

            // Tarkistetaan, onko peli päättynyt
            if (pairsFound == tiles.Count / 2) // Oikeiden parien määrä on puolet kaikista laatoista
            {
                Debug.Log("Kaikki parit löydetty! Palapeli ratkaistu.");
                PuzzleSolved();
            }
        }
        else
        {
            // Jos pari ei ole oikein, käännä laatat takaisin piiloon
            firstRevealedTile.HideTile();
            secondRevealedTile.HideTile();
        }

        // Nollataan valitut laatat
        firstRevealedTile = null;
        secondRevealedTile = null;
        IsCheckingTiles = false;
    }

    private void PuzzleSolved()
    {
        // Toiminnot palapelin ratkaisun jälkeen
        Debug.Log("Palapeli ratkaistu!");
        // Esim. avaa seuraava ovi tai anna palkinto
    }
}
