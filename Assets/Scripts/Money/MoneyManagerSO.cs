using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MoneyManagerSO", menuName = "ScriptableObjects/Money Manager")]
public class MoneyManagerSO : ScriptableObject
{
    [SerializeField]
    private int initMoney;
    [SerializeField]
    private int currentMoney;

    [System.NonSerialized]
    public UnityEvent<int> moneyChangeEvent;
    [System.NonSerialized]
    public UnityEvent notEnoughMoneyEvent;

    private void OnEnable()
    {
        currentMoney = initMoney;
        if (moneyChangeEvent == null)
            moneyChangeEvent = new UnityEvent<int>();
        if (notEnoughMoneyEvent == null)
            notEnoughMoneyEvent = new UnityEvent();
    }

    public void DecreaseMoney(int amount)
    {
        if (currentMoney <= 0)
        {
            notEnoughMoneyEvent.Invoke();
            return;
        }

        currentMoney -= amount;
        if (currentMoney <= 0)
        {
            currentMoney = 0;
        }
        moneyChangeEvent.Invoke(currentMoney);
    }

    public void IncrementMoney(int amount)
    {
        currentMoney += amount;
        moneyChangeEvent.Invoke(currentMoney);
    }

}
