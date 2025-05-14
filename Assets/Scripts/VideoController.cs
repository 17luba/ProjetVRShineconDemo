using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [Header("Composants")]
    public GameObject videoPanel;         // Panel contenant la vid�o
    public VideoPlayer videoPlayer;       // Le lecteur vid�o
    public GameObject linkedStartCanvas;  // Le canvas � r�afficher quand la vid�o se termine
    public GazeInteraction gazeInteraction; // Si besoin d'activer le gameplay � la fin

    private bool isClosingManually = false;

    void Start()
    {
        videoPanel.SetActive(false);
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    public void PlayVideo()
    {
        isClosingManually = false;
        linkedStartCanvas.SetActive(false);
        videoPanel.SetActive(true);
        videoPlayer.Play();
    }

    public void CloseVideo()
    {
        isClosingManually = true;
        videoPlayer.Stop();
        videoPanel.SetActive(false);
        linkedStartCanvas.SetActive(true);
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (!isClosingManually)
        {
            videoPanel.SetActive(false);
            linkedStartCanvas.SetActive(true);

            if (gazeInteraction != null)
            {
                gazeInteraction.enabled = true;
            }
        }
    }
}
