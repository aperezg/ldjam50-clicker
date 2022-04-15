using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Dependencies")]
    public TMP_Text timer;
    public TimerManagerSO timerManager;

    [Header("Configuration")]
    public bool timerStarted;

    private void OnEnable()
    {
        timerManager.timerChangeEvent.AddListener(DrawTimer);
    }

    private void OnDisable()
    {
        timerManager.timerChangeEvent.RemoveListener(DrawTimer);
    }

    // Update is called once per frame
    void Update()
    {
        timerManager.DecreaseTime(Time.deltaTime);
    }

    private void DrawTimer(float currentTimer)
    {
        var minutes = TimeSpan.FromSeconds(currentTimer).Minutes;
        var seconds = TimeSpan.FromSeconds(currentTimer).Seconds;

        var minutesStr = (minutes < 10) ? string.Concat("0", minutes.ToString()) : minutes.ToString();
        var secondsStr = (seconds < 10) ? string.Concat("0", seconds.ToString()) : seconds.ToString();


        timer.text = string.Format("{0}:{1}", minutesStr, secondsStr);
    }
}
