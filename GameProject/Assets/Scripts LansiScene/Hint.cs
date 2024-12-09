using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hint : MonoBehaviour
{
    public TextMeshPro panelText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            panelText.text = "Etsi valokuvia, jotta p‰‰set etenem‰‰n.";
        }
    }
}