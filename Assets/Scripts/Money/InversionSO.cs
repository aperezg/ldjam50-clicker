using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="InversionSO", menuName ="ScriptableObjects/Inversion")]
public class InversionSO : ScriptableObject
{
    public enum InversionType
    {
        HealthCare,
        Defense,
        Enviornment
    }

    public MoneyManagerSO moneyManager;

    [SerializeField]
    private InversionType inversionType;
    [SerializeField]
    private int baseCost;
    [SerializeField]
    private int currentCos;
    [SerializeField]
    private int currentInversion;
    [SerializeField]
    private int incrementor;

    [System.NonSerialized]
    public UnityEvent<InversionType, int> investEvent;
    [System.NonSerialized]
    public UnityEvent<InversionType, int> changeCostEvent;

    public InversionType Type { get => inversionType; }
    public int Inversion { get => currentInversion; }
    public int Cost { get => currentCos; }
    // Start is called before the first frame update
    private void OnEnable()
    {
        Reset();
        if (investEvent == null)
            investEvent = new UnityEvent<InversionType, int>();

        if (changeCostEvent == null)
            changeCostEvent = new UnityEvent<InversionType, int>();
    }

    public void Reset()
    {
        currentCos = baseCost;
        currentInversion = 0;
    }

    public void Invest()
    {
        if (CanInvest())
        {
            currentInversion += currentCos;
            moneyManager.DecrementMoney(currentCos);
            investEvent.Invoke(inversionType, currentCos);

            ModifyCost();            
        }  else
        {
            moneyManager.NotEnoughMoney();
        }
    }

    private void ModifyCost()
    {
        currentCos += incrementor;
        changeCostEvent.Invoke(inversionType, currentCos);
    }

    private bool CanInvest()
    {
        return moneyManager.CurrentMoney - currentCos >= 0;
    }
}
