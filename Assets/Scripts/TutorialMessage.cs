using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
    public float displayDuration = 5f;

    void Start()
    {
        // Lancer la d�sactivation dans X secondes
        Invoke(nameof(HideMessage), displayDuration);
    }

    void HideMessage()
    {
        gameObject.SetActive(false);
    }
}
