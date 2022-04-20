using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [Header("Dependencies")]
    public TimerManagerSO timerManager;
    public List<InversionSO> inversions;
    public MoneyManagerSO moneyManager;
    public QuestManagerSO questManager;


    private void OnEnable()
    {
        timerManager.timerEndsEvent.AddListener(GameOverScene);
    }

    private void OnDisable()
    {
        timerManager.timerEndsEvent.RemoveListener(GameOverScene);
    }


    private void GameOverScene()
    {
        StartCoroutine(GameOverAfterExplosion());
    }

    private IEnumerator GameOverAfterExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameOver");
    }

    public void MainScene()
    {
        timerManager.StartTimer();
        moneyManager.Reset();
        inversions.ForEach((x) => x.Reset());
        questManager.Reset();
        SceneManager.LoadScene("Main");
    }
}
