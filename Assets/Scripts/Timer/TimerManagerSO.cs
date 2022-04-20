using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TimerManagerSO", menuName = "ScriptableObjects/Timer Manager")]
public class TimerManagerSO : ScriptableObject
{
    [SerializeField]
    private float initTime;
    [SerializeField] 
    private float currentTimer;
    [SerializeField]
    private bool timerRunning;
    [SerializeField]
    private float timeRewarded;

    [System.NonSerialized]
    public UnityEvent timerEndsEvent;
    [System.NonSerialized]
    public UnityEvent<float> timerChangeEvent;

    public float TimeRewarded { get => timeRewarded;}

    private void OnEnable()
    {
        StartTimer();

        if (timerEndsEvent == null)
            timerEndsEvent = new UnityEvent();
        if (timerChangeEvent == null)
            timerChangeEvent = new UnityEvent<float>();
    }

    public void StartTimer()
    {
        currentTimer = initTime;
        timeRewarded = 0;
        timerRunning = true;
    }

    public void DecreaseTime(float amount)
    {
        if (timerRunning)
        {
            currentTimer -= amount;
            if (currentTimer < 0.75f)
            {
                currentTimer = 0;
                timerRunning = false;
                timerEndsEvent.Invoke();
            }
            timerChangeEvent.Invoke(currentTimer);
        }
    }

    public void AddTime(float amount)
    {
        if (currentTimer < 0.75f)
        {
            return;
        }
        currentTimer += amount;
        timeRewarded += amount;

        timerChangeEvent.Invoke(currentTimer);
    }

}
