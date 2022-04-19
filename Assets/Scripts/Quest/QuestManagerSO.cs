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
    [System.NonSerialized]
    public UnityEvent<Quest> questAdded;
    [System.NonSerialized]
    public UnityEvent<string> questCompleted;
    
    public List<Quest> Quests { get => quests; }
    public void OnEnable()
    {
        if (quests == null)
            quests = new List<Quest>();

        if (questsUpdated == null)
            questsUpdated = new UnityEvent();

        if (questAdded == null)
            questAdded = new UnityEvent<Quest>();

        if (questCompleted == null)
            questCompleted = new UnityEvent<string>();
 
    }

    public void AddQuest(Quest quest)
    {
        quest.progressCompleted.AddListener(QuestCompleted);

        quests.Add(quest);
        questAdded.Invoke(quest);
    }

    private void QuestCompleted(string questID)
    {
        Quest q = quests.Find((x) => x.ID == questID);
        quests.Remove(q);

        //TODO: this should be configure on the quest?
        timerManager.AddTime(30);

        questCompleted.Invoke(q.ID);
    }

    public void UpdateQuests(InversionSO.InversionType inversionType, int invest)
    {
       var questsByType = quests.FindAll(delegate (Quest q) { return q.Type == (Quest.QuestType)inversionType; });
       questsByType.ForEach((x) => x.Progress(invest));

       questsUpdated.Invoke();
    }

    public Quest GetQuestByID(string questID)
    {
        return quests.Find((x) => x.ID == questID);
    }
}
