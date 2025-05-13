using UnityEngine;
using TMPro;

public class GazeUIManager : MonoBehaviour
{
    [Header("Lien vers le champ texte")]
    [SerializeField] private TextMeshProUGUI interactionText;

    [Header("Conteneur parent (Image) pour visuel")]
    [SerializeField] private GameObject textContainer;

    private void Awake()
    {
        HideMessage(); // Cache le texte au démarrage
    }

    public void ShowMessage(string message)
    {
        if (interactionText != null)
        {
            interactionText.text = message;
            if (textContainer != null)
                textContainer.SetActive(true);
        }
    }

    public void HideMessage()
    {
        if (interactionText != null)
        {
            interactionText.text = "";
        }

        if (textContainer != null)
        {
            textContainer.SetActive(false);
        }
    }
}
