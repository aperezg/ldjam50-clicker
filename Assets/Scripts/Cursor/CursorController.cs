using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [Header("Dependencies")]
    public Texture2D cursor;

    private CursorActions _actions;

    private void Awake()
    {
        _actions = new CursorActions();
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Confined;
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
        
    }

}
