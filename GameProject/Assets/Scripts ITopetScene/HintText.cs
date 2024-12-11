using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintText : MonoBehaviour
{
    public TextMeshPro panelText;

    public void HintBtnClicked()
    {
        panelText.text = "Etsi kirjoja päästäksesi eroon Yrjöstä ja muista opettajista";
    }
}