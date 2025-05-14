using UnityEngine;
using UnityEngine.Video;

public class StartSequenceManager : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject videoPanel;
    public VideoPlayer videoPlayer;

    public GazeInteraction gazeInteraction; // le script qui permet d'avancer (désactivé au début)

    void Start()
    {
        videoPanel.SetActive(false);
        gazeInteraction.enabled = false;
    }

    public void LancerLaVideo()
    {
        startCanvas.SetActive(false);
        videoPanel.SetActive(true);
        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        videoPanel.SetActive(false);
        gazeInteraction.enabled = true;
    }
}
