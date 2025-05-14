using UnityEngine;
using UnityEngine.Events;

public class GazeButton : MonoBehaviour
{
    public float gazeDuration = 1.5f;
    public UnityEvent onGazeComplete;

    private float timer = 0f;
    private bool isGazing = false;

    public void StartGaze()
    {
        isGazing = true;
        timer = 0f;
    }

    public void StopGaze()
    {
        isGazing = false;
        timer = 0f;
    }

    void Update()
    {
        if (isGazing)
        {
            timer += Time.deltaTime;
            if (timer >= gazeDuration)
            {
                isGazing = false;
                onGazeComplete?.Invoke();
            }
        }
    }
}
