using UnityEngine;

public class GazeButtonEvents : MonoBehaviour
{
    private GazeButton gazeButton;

    void Awake()
    {
        gazeButton = GetComponent<GazeButton>();
    }

    void OnPointerEnter()
    {
        gazeButton?.StartGaze();
    }

    void OnPointerExit()
    {
        gazeButton?.StopGaze();
    }
}
