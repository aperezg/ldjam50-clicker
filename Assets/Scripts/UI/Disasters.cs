using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disasters : MonoBehaviour
{
    [Header("Dependencies")]
    public QuestManagerSO questManager;
    public GameObject questPanel;
    public GameObject questPrefab;


    private void OnEnable()
    {
        questManager.questAdded.AddListener(PrintQuest);
        questManager.questsUpdated.AddListener(ModifyQuests);
        questManager.questCompleted.AddListener(RemoveQuest);
    }

    private void OnDisable()
    {
        questManager.questAdded.RemoveListener(PrintQuest);
        questManager.questsUpdated.RemoveListener(ModifyQuests);
        questManager.questCompleted.RemoveListener(RemoveQuest);
    }

    private void PrintQuest(Quest quest)
    {
        var q = Instantiate(questPrefab, Vector3.zero, Quaternion.identity);
        q.transform.SetParent(questPanel.transform);
        q.transform.localScale = new Vector3(1f, 1f, 1f);
        q.GetComponent<RectTransform>().localPosition = Vector3.zero;
        q.GetComponent<Disaster>().Initialize(quest.ID, quest.QuestName(), quest.Type, quest.Goal);       
    }

    private void ModifyQuests() {
        Disaster[] disasters = questPanel.GetComponentsInChildren<Disaster>();

        var quests = questManager.Quests;
        foreach(var quest in quests)
        {
           foreach (var disaster in disasters)
            {
                if (disaster.DisasterID == quest.ID)
                {
                    disaster.ModifyProgress(quest.CurrentProgress);
                }
            }
        }
    }

    private void RemoveQuest(string questID)
    {
        Disaster[] disasters = questPanel.GetComponentsInChildren<Disaster>();
        foreach (var disaster in disasters)
        {
            if (disaster.DisasterID == questID)
            {
                Destroy(disaster.gameObject);
            }
        }
    }
}
