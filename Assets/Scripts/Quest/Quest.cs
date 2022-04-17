using UnityEngine;
using UnityEngine.Events;

public class Quest
{
    public enum QuestType
    {
        HealthCare,
        Defense,
        Enviornment
    }

    private string questID;
    private QuestType questType;
    private int goal;
    private int goalProgress;

    public UnityEvent<string> progressCompleted;

    public QuestType Type { get => questType; }
    public string ID { get => questID; }

    public Quest(int goal)
    {
        float randomType = Random.Range(0, 2);

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
}
