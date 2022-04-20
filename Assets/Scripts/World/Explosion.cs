using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Dependencies")]
    public TimerManagerSO timerManager;
    public GameObject explosion;

    private void OnEnable()
    {
        timerManager.timerEndsEvent.AddListener(Explode);
    }

    private void OnDisable()
    {
        timerManager.timerEndsEvent.RemoveListener(Explode);
    }
    

    private void Explode()
    {
        explosion.SetActive(true);
        gameObject.SetActive(false);
    }
}
