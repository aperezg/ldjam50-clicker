using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static InversionSO;

public class Economy : MonoBehaviour
{
    [Header("Dependencies")]
    public TMP_Text healthCareText;
    public TMP_Text defenseText;
    public TMP_Text environmentText;
    [SerializeField] public List<InversionSO> inversions;


    private void OnEnable()
    {
        inversions.ForEach((x) => x.changeCostEvent.AddListener(ChangeEconomy));
    }

    private void OnDisable()
    {
        inversions.ForEach((x) => x.changeCostEvent.RemoveListener(ChangeEconomy));
    }

    private void ChangeEconomy(InversionType inversionType, int cost)
    {
        switch(inversionType)
        {
            case InversionType.HealthCare:
                healthCareText.text = string.Format("{0}$", cost.ToString());
                break;
            case InversionType.Defense:
                defenseText.text = string.Format("{0}$", cost.ToString());
                break;
            case InversionType.Enviornment:
                environmentText.text = string.Format("{0}$", cost.ToString());
                break;
        }
    }
}
