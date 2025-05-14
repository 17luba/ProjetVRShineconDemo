using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [Header("Composants")]
    public GameObject videoPanel;         // Panel contenant la vidéo
    public VideoPlayer videoPlayer;       // Le lecteur vidéo
    public GameObject linkedStartCanvas;  // Le canvas à réafficher quand la vidéo se termine
    public GazeInteraction gazeInteraction; // Si besoin d'activer le gameplay à la fin

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
