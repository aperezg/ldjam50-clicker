using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="QuestManagerSO", menuName ="ScriptableObjects/Quest Manager")]
public class QuestManagerSO : ScriptableObject
{
    private List<Quest> quests;
    [SerializeField]
    private List<InversionSO> inversions;
    [SerializeField]
    private TimerManagerSO timerManager;

    [System.NonSerialized]
    public UnityEvent questsUpdated;
    
    public List<Quest> Quests { get => quests; }
    public void OnEnable()
    {
        inversions.ForEach((x) => x.investEvent.AddListener(UpdateQuests));
        if (quests == null)
            quests = new List<Quest>();

        if (questsUpdated == null)
            questsUpdated = new UnityEvent();
    }

    public void OnDisable()
    {
        inversions.ForEach((x) => x.investEvent.RemoveListener(UpdateQuests));
    }

    public void AddQuest()
    {
        //TODO:Change goal in base of some algorithm
        Quest quest = new Quest(1000);
        quest.progressCompleted.AddListener(QuestCompleted);

        quests.Add(quest);
        questsUpdated.Invoke();

        Debug.Log("New Quest:" + quest.ID);
    }

    private void QuestCompleted(string questID)
    {
        Quest q = quests.Find((x) => x.ID == questID);
        quests.Remove(q);

        //TODO: this should be configure on the quest?
        timerManager.AddTime(30);

        questsUpdated.Invoke();
    }

    private void UpdateQuests(InversionSO.InversionType inversionType, int invest)
    {
       var questsByType = quests.FindAll(delegate (Quest q) { return q.Type == (Quest.QuestType)inversionType; });
       questsByType.ForEach((x) => x.Progress(invest));

       questsUpdated.Invoke();
    }
}
