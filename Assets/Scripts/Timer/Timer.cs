using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Dependencies")]
    public TMP_Text timer;

    [Header("Configuration")]
    public float startTime;
    public bool timerStarted;

    private float _currentTime;

    // Start is called before the first frame update
    void Start()
    {
        _currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                timerStarted = false;
                _currentTime = 0;
            }
        }
        Draw();
    }

    private void Draw()
    {
        var minutes = TimeSpan.FromSeconds(_currentTime).Minutes;
        var seconds = TimeSpan.FromSeconds(_currentTime).Seconds;

        var minutesStr = (minutes < 10) ? string.Concat("0", minutes.ToString()) : minutes.ToString();
        var secondsStr = (seconds < 10) ? string.Concat("0", seconds.ToString()) : seconds.ToString();


        timer.text = string.Format("{0}:{1}", minutesStr, secondsStr);
    }
}
