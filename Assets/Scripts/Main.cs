using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public float speed = 10;
    public Vector3 dir = Vector3.zero;
    private Controller controller;

    private UIDocument ui;

    void Start()
    {
        var ui = GetComponentInChildren<UIDocument>(true).rootVisualElement;
        var btStart = ui.Q<Button>("Start");
        btStart.clicked += OnStartClick;
    }

    private void OnStartClick()
    {
        Debug.Log("OnStartClick");
        SceneManager.LoadScene("Game");
    }


}
