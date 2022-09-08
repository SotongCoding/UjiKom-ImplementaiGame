using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown
{
    private float currentTimerPrecent;
    private float currentCount = 0;
    private float answerTime = 30;

    public System.Action onTimesUp;

    public IEnumerator StartTimerCount(System.Action<float, int> onTimeChange = null)
    {
        currentCount = answerTime;
        Debug.Log("Initial Time");
        while (currentCount > 0)
        {
            Debug.Log("Count Time");
            currentCount -= Time.deltaTime;
            currentTimerPrecent = currentCount / answerTime;
            yield return null;

            onTimeChange?.Invoke(currentTimerPrecent, (int)currentCount);
        }
        onTimesUp?.Invoke();
    }
}
