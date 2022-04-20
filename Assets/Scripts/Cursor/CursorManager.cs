using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Dependencies")]
    public Texture2D cursor;

    private CursorActions _actions;
    private Camera _mainCamera;

    private void Awake()
    {
        _actions = new CursorActions();
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Confined;
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _actions.Enable();
    }

    private void OnDisable()
    {
        _actions.Disable();
    }

    private void Start()
    {
        _actions.Click.Click.performed += _ => EndedClick();
    }

    private void EndedClick()
    {
        DetectObject();
    }
    
    private void DetectObject()
    {
        Ray ray = _mainCamera.ScreenPointToRay(_actions.Click.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
               IClickable click = hit.collider.gameObject.GetComponent<IClickable>();
               if (click != null) click.OnClickAction();
            }
        }
    }
}
