using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{

    [Header("Dependencies")]
    public MoneyManagerSO moneyManager;
    public GameObject notEnoughMoneyToast;

    private void OnEnable()
    {
        moneyManager.notEnoughMoneyEvent.AddListener(NotEnoughMoneyToast);
    }

    private void OnDisable()
    {
        moneyManager.notEnoughMoneyEvent.AddListener(NotEnoughMoneyToast);
    }

   
    private void NotEnoughMoneyToast()
    {
        StartCoroutine(ShowNotEnoughMoneyToast());
    }

    private IEnumerator ShowNotEnoughMoneyToast()
    {
        notEnoughMoneyToast.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        notEnoughMoneyToast.SetActive(false);
    }
}
