using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [Header("Dependencies")]
    public MoneyManagerSO moneyManager;
    public TMP_Text moneyText;
    [SerializeField] public List<InversionSO> inversions;


    private void OnEnable()
    {
        moneyManager.moneyChangeEvent.AddListener(DrawMoney); 
    }

    private void OnDisable()
    {
        moneyManager.moneyChangeEvent.RemoveListener(DrawMoney);
    }

    private void DrawMoney(int amount)
    {
        moneyText.text = string.Format("{0}$", amount.ToString());
    }

    public void IncrementMoney()
    {
        moneyManager.IncrementMoney();
    }
}
