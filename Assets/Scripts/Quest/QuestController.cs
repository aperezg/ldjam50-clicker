using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Quest;

public class QuestController : MonoBehaviour
{
    [Header("Dependencies")]
    public QuestManagerSO questManager;
    [SerializeField] public List<InversionSO> inversions;

    [Header("Configuration")]
    public int questsPerSecond;
    public int maxQuests;


    private float _remainingTimeQuest;
    private QuestType _lastQuestType;


    private void OnEnable()
    {
        _remainingTimeQuest = 0;
        _lastQuestType = QuestType.None;

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

        questManager.AddQuest(NextQuest());
        _remainingTimeQuest = 0;
    }

    private Quest NextQuest()
    {
        //TODO:Change goal in base of some algorithm

        var quest = new Quest(1000);
        if (quest.Type == _lastQuestType)
        {
            return NextQuest();
        }
        _lastQuestType = quest.Type;
        return quest;
    }

    private void UpdateQuests(InversionSO.InversionType inversionType, int invest)
    {
        questManager.UpdateQuests(inversionType, invest);
    }
}
