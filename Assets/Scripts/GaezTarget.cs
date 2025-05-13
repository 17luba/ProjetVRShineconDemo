using UnityEngine;

public class GazeTarget : MonoBehaviour
{
    [TextArea]
    public string gazeMessage = "Regardez {name} pour avancer !";

    /// <summary>
    /// Renvoie le message avec {name} remplacé par le nom réel de l'objet
    /// </summary>
    public string GetFormattedMessage()
    {
        return gazeMessage.Replace("{name}", gameObject.name);
    }
}
