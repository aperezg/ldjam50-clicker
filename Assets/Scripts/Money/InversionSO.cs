using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="InversionSO", menuName ="ScriptableObjects/Inversion")]
public class InversionSO : ScriptableObject
{
    public MoneyManagerSO moneyManager;

    [SerializeField]
    private string inversionName;
    [SerializeField]
    private int baseCost;
    [SerializeField]
    private int currentCos;
    [SerializeField]
    private int currentInversion;
    [SerializeField]
    private int incrementor;

    [System.NonSerialized]
    public UnityEvent<int> investEvent;
    [System.NonSerialized]
    public UnityEvent<int> changeCostEvent;

    public string Name { get => inversionName; }
    public int Inversion { get => currentInversion; }
    public int Cost { get => currentCos; }
    // Start is called before the first frame update
    private void OnEnable()
    {
        currentCos = baseCost;
        currentInversion = 0;
        if (investEvent == null)
            investEvent = new UnityEvent<int>();

        if (changeCostEvent == null)
            changeCostEvent = new UnityEvent<int>();
    }

    public void Invest()
    {
        if (CanInvest())
        {
            currentInversion += currentCos;
            moneyManager.DecrementMoney(currentCos);

            ModifyCost();
        }  else
        {
            moneyManager.NotEnoughMoney();
        }
    }

    private void ModifyCost()
    {
        currentCos += incrementor;
        changeCostEvent.Invoke(currentCos);
    }

    private bool CanInvest()
    {
        return moneyManager.CurrentMoney - currentCos >= 0;
    }
}
