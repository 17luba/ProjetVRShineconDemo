using UnityEngine;

public class GazeVideoLauncher : MonoBehaviour
{
    public VideoController videoController;
    public float gazeDuration = 1.5f;

    private float gazeTimer = 0f;
    private bool isGazing = false;

    public void StartGaze()
    {
        gazeTimer = 0f;
        isGazing = true;
    }

    public void StopGaze()
    {
        gazeTimer = 0f;
        isGazing = false;
    }

    void Update()
    {
        if (isGazing)
        {
            gazeTimer += Time.deltaTime;
            if (gazeTimer >= gazeDuration)
            {
                isGazing = false;
                videoController.PlayVideo();
            }
        }
    }

    void OnPointerEnter() => StartGaze();
    void OnPointerExit() => StopGaze();
}
