using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Disaster : MonoBehaviour
{
    [Header("Dependencies")]
    public TMP_Text disasterName;
    public TMP_Text goal;

    private string _disasterID;
    private int _disasterGoal;

    public string DisasterID { get => _disasterID; }

    public void Initialize(string disasterID, string disasterName, int disasterGoal)
    {
        _disasterID = disasterID;
        this.disasterName.text = disasterName;
        _disasterGoal = disasterGoal;

        ModifyProgress(0);
    }

    public void ModifyProgress(int progress)
    {
        string g = string.Format("{0}/{1}$", progress, _disasterGoal);
        goal.text = g;
    }
}
