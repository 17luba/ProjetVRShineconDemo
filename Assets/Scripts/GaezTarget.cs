using UnityEngine;

public class GazeTarget : MonoBehaviour
{
    [TextArea]
    public string gazeMessage = "Regardez la {name} au sol pour avancer !";

    /// <summary>
    /// Renvoie le message avec {name} remplac� par le nom r�el de l'objet
    /// </summary>
    public string GetFormattedMessage()
    {
        return gazeMessage.Replace("{name}", gameObject.name);
    }
}
