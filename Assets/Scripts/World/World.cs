using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class World : MonoBehaviour, IClickable
{
    [Header("Dependencies")]
    public MoneyManagerSO moneyManager;

    private Transform _transform;
    [SerializeField]
    private Vector3 _scaleChange;
    private bool _onClickActive;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickAction()
    {
        StartCoroutine(Click());
        //TODO: this amount should be calculate in base a level or something on the money manager directly
        moneyManager.IncrementMoney(5);
    }

    private IEnumerator Click()
    {
        if (!_onClickActive)
        {
            _onClickActive = true;
            _transform.localScale += _scaleChange;
            yield return new WaitForSeconds(0.1f);
            _transform.localScale -= _scaleChange;
            _onClickActive = false;
        }
    }
}
