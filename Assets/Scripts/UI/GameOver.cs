using System;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Dependencies")]
    public TMP_Text timerRewardedText;
    public TimerManagerSO timerManager;

    private void OnEnable()
    {
       var timerRewarded = timerManager.TimeRewarded;

        var minutes = TimeSpan.FromSeconds(timerRewarded).Minutes;
        var seconds = TimeSpan.FromSeconds(timerRewarded).Seconds;

        var minutesStr = (minutes < 10) ? string.Concat("0", minutes.ToString()) : minutes.ToString();
        var secondsStr = (seconds < 10) ? string.Concat("0", seconds.ToString()) : seconds.ToString();


        timerRewardedText.text = string.Format("{0}m {1}s", minutesStr, secondsStr);
    }
}
