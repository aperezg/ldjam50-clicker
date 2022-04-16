using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class World : MonoBehaviour, IClickable
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent clickEvent;

    private Transform _transform;
    [SerializeField]
    private Vector3 _scaleChange;
    private bool _onClickActive;

    private void OnEnable()
    {
        _transform = GetComponent<Transform>();
        if (clickEvent == null)
        {
            clickEvent = new UnityEvent();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAction()
    {
        StartCoroutine(Click());
        clickEvent.Invoke();
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
