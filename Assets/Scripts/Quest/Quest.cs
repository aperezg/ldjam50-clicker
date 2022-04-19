using UnityEngine;
using UnityEngine.Events;

public class Quest
{
    public enum QuestType
    {
        HealthCare,
        Defense,
        Enviornment,
        None
    }

    private string questID;
    private QuestType questType;
    private int goal;
    private int goalProgress;

    public UnityEvent<string> progressCompleted;

    public QuestType Type { get => questType; }
    public string ID { get => questID; }
    public int Goal { get => goal; }
    public int CurrentProgress { get => goalProgress; }

    public Quest(int goal)
    {
        float randomType = Random.Range(0, 3);

        this.questID = System.Guid.NewGuid().ToString();
        this.goal = goal;
        this.questType = (QuestType)randomType;
        this.goalProgress = 0;
        this.progressCompleted = new UnityEvent<string>();
    }

    public void Progress(int amount)
    {
        goalProgress += amount;

        if (goalProgress >= goal)
        {
            goalProgress = goal;
            progressCompleted.Invoke(questID);
        }
    }

    public string QuestName()
    {
        switch (questType)
        {
            case QuestType.HealthCare:
                return "A new mortal virus";
            case QuestType.Defense:
                return "A mortal meteor";
            case QuestType.Enviornment:
                return "The global warming";
            default:
                return "";
        }
    }
}
