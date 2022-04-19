using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Quest;

public class Disaster : MonoBehaviour
{
    [Header("Dependencies")]
    public TMP_Text disasterName;
    public TMP_Text goal;
    public Image image;

    private string _disasterID;
    private int _disasterGoal;

    public string DisasterID { get => _disasterID; }

    public void Initialize(string disasterID, string disasterName, QuestType questType, int disasterGoal)
    {
        _disasterID = disasterID;
        this.disasterName.text = disasterName;
        _disasterGoal = disasterGoal;

        ModifyProgress(0);

        switch(questType)
        {
            case QuestType.HealthCare:
                image.sprite = Resources.Load<Sprite>("Art/UI/healthcare");
                image.color = new Color32(32, 160, 225, 255);
                break;
            case QuestType.Defense:
                image.sprite = Resources.Load<Sprite>("Art/UI/defense");
                image.color = new Color32(223, 103, 26, 255);
                break;
            case QuestType.Enviornment:
                image.sprite = Resources.Load<Sprite>("Art/UI/environment");
                image.color = new Color32(111, 195, 75, 255);
                break;
        }
    }

    public void ModifyProgress(int progress)
    {
        string g = string.Format("{0}/{1}$", progress, _disasterGoal);
        goal.text = g;
    }
}
