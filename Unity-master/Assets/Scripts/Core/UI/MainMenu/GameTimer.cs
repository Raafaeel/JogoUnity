using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float startTime;
    private bool isRunning;

    public float ElapsedTime
    {
        get
        {
            if (isRunning)
            {
                return Time.time - startTime;
            }
            return 0f;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
