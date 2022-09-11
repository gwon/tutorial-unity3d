using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour, Controller.IPlayerActions
{
    public float speed = 10;
    public Vector3 dir = Vector3.zero;
    private Controller controller;

    private UIDocument ui;

    void Start()
    {
        controller = new Controller();
        controller.Player.Enable();
        controller.Player.SetCallbacks(this);

        var ui = GetComponentInChildren<UIDocument>(true).rootVisualElement;
        var btStart = ui.Q<Button>("Start");
        btStart.clicked += OnStartClick;
    }

    private void OnStartClick()
    {
        Debug.Log("OnStartClick");
        SceneManager.LoadScene("Game");
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("OnFire");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("On move >>> " + dir);
        dir = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("OnLook >>> " + context);
    }
}
