using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [Header("Dependencies")]
    public QuestManagerSO questManager;
    [SerializeField] public List<InversionSO> inversions;

    [Header("Configuration")]
    public int questsPerSecond;
    public int maxQuests;


    private float _remainingTimeQuest;


    private void OnEnable()
    {
        _remainingTimeQuest = 0;
        inversions.ForEach((x) => x.investEvent.AddListener(UpdateQuests));
    }

    private void OnDisable()
    {
        inversions.ForEach((x) => x.investEvent.RemoveListener(UpdateQuests));
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

        //TODO:Change goal in base of some algorithm
        Quest quest = new Quest(1000);

        questManager.AddQuest(quest);
        _remainingTimeQuest = 0;
    }

    private void UpdateQuests(InversionSO.InversionType inversionType, int invest)
    {
        questManager.UpdateQuests(inversionType, invest);
    }
}
