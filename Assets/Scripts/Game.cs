using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Game : MonoBehaviour, Controller.IPlayerActions, Controller.IUIActions
{
    public GameObject dino;
    public GameObject miniBoo;
    public float speed = 10;
    public Vector3 dir = Vector3.zero;
    private Controller controller;
    private Vector3 mousePos = Vector2.zero;

    private UIDocument ui;
    void Start()
    {
        controller = new Controller();
        controller.Player.Enable();
        controller.Player.SetCallbacks(this);
        var ui = GetComponentInChildren<UIDocument>(true).rootVisualElement;
        var btExit = ui.Q<Button>("Exit");
        btExit.clicked += OnExitClick;

        controller.UI.Enable();
        controller.UI.SetCallbacks(this);
    }

    private void OnExitClick()
    {
        Debug.Log("OnExitClick");
        SceneManager.LoadScene("Main");

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

    void Update()
    {
        Vector3 next = dino.transform.position + dir * Time.deltaTime * speed;
        dino.transform.position = next;
        if ((int)dir.x != 0)
        {
            var scale = dino.transform.localScale;
            scale.x = dir.x;
            dino.transform.localScale = scale;
        }
    }

    void Controller.IUIActions.OnNavigate(InputAction.CallbackContext context)
    {
        Debug.Log($"OnNavigate");

    }

    void Controller.IUIActions.OnSubmit(InputAction.CallbackContext context)
    {
        Debug.Log($"OnSubmit");

    }

    void Controller.IUIActions.OnCancel(InputAction.CallbackContext context)
    {
        Debug.Log($"OnCancel");
    }

    void Controller.IUIActions.OnPoint(InputAction.CallbackContext context)
    {
        mousePos = context.ReadValue<Vector2>();
        Debug.Log($"position >>> {mousePos.x}, {mousePos.y}");
    }

    void Controller.IUIActions.OnClick(InputAction.CallbackContext context)
    {
        Debug.Log($"OnClick");
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        pos.z = 0;
        dino.transform.DOMove(pos, 0.5f);
    }

    void Controller.IUIActions.OnScrollWheel(InputAction.CallbackContext context)
    {
        Debug.Log($"OnScrollWheel");

    }

    void Controller.IUIActions.OnMiddleClick(InputAction.CallbackContext context)
    {
        Debug.Log($"OnMiddleClick");

    }

    void Controller.IUIActions.OnRightClick(InputAction.CallbackContext context)
    {
        Debug.Log($"OnRightClick");

    }

    void Controller.IUIActions.OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        Debug.Log($"OnTrackedDevicePosition");

    }

    void Controller.IUIActions.OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        Debug.Log($"OnTrackedDeviceOrientation");

    }
}
