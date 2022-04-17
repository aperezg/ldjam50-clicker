using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [Header("Dependencies")]
    public QuestManagerSO questManager;

    public int questsPerSecond;
    public int maxQuests;

    private int _currentQuests;
    private float _remainingTimeQuest;


    private void OnEnable()
    {
        _currentQuests = 0;
        _remainingTimeQuest = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (questManager.Quests.Count >= maxQuests)
            return;

        if (_remainingTimeQuest < questsPerSecond)
        {
            _remainingTimeQuest += Time.deltaTime;
            return;
        }

        questManager.AddQuest();
        _remainingTimeQuest = 0;  
    }
}
