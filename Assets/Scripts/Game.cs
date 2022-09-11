using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour, Controller.IPlayerActions
{
    public GameObject dino;
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
        var btExit = ui.Q<Button>("Exit");
        btExit.clicked += OnExitClick;
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
}
