using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlkuPanelTextChange : MonoBehaviour
{
    public TextMeshPro panelText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            panelText.text = "Etsi kirjoja p��st�ksesi eroon Yrj�st� ja muista opettajista";
        }
    }
}