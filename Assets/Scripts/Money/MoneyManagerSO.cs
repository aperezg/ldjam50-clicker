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
    [SerializeField]
    private int incrementBase;


    [System.NonSerialized]
    public UnityEvent<int> moneyChangeEvent;
    [System.NonSerialized]
    public UnityEvent notEnoughMoneyEvent;

    public int CurrentMoney { get => currentMoney; }

    private void OnEnable()
    {
        currentMoney = initMoney;
        if (moneyChangeEvent == null)
            moneyChangeEvent = new UnityEvent<int>();
        if (notEnoughMoneyEvent == null)
            notEnoughMoneyEvent = new UnityEvent();
    }

    public void Reset()
    {
        currentMoney = initMoney;
    }

    public void DecrementMoney(int decrement)
    {
        currentMoney -= decrement;

        if (currentMoney <= 0)
        {
            currentMoney = 0;
        }
        moneyChangeEvent.Invoke(currentMoney);
    }

    public void NotEnoughMoney()
    {
        notEnoughMoneyEvent.Invoke();
    }

    public void IncrementMoney()
    {
        currentMoney += incrementBase;
        moneyChangeEvent.Invoke(currentMoney);
    }

}
