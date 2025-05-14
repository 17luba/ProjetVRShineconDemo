using UnityEngine;
using UnityEngine.Video;

public class StartSequenceManager : MonoBehaviour
{
    public GameObject[] allStartCanvases;
    public GazeInteraction gazeInteraction;

    private GameObject currentPanel;
    private VideoPlayer currentPlayer;

    private GameObject hiddenStartCanvas;


    private bool isClosingManually = false;

    void Start()
    {
        foreach (GameObject canvas in allStartCanvases)
        {
            canvas.SetActive(true);
        }

        gazeInteraction.enabled = false;
    }

    public void LancerLaVideoDepuisBouton(GameObject panel, VideoPlayer player, GameObject canvasToHide)
    {
        isClosingManually = false;

        hiddenStartCanvas = canvasToHide;
        hiddenStartCanvas.SetActive(false); // ❌ ne cache que le bon Canvas

        currentPanel = panel;
        currentPlayer = player;

        currentPanel.SetActive(true);
        currentPlayer.Play();
        currentPlayer.loopPointReached += OnVideoEnd;
    }


    void OnVideoEnd(VideoPlayer vp)
    {
        if (!isClosingManually)
        {
            currentPanel.SetActive(false);
            if (hiddenStartCanvas != null)
            {
                hiddenStartCanvas.SetActive(true); // ✅ on ne réactive que celui qu'on avait masqué
            }

            gazeInteraction.enabled = true;
        }
    }

    public void FermerVideo()
    {
        isClosingManually = true;

        if (currentPlayer != null) currentPlayer.Stop();
        if (currentPanel != null) currentPanel.SetActive(false);

        if (hiddenStartCanvas != null)
        {
            hiddenStartCanvas.SetActive(true); // ✅ on ne réactive que celui qu'on avait masqué
        }

    }
}
