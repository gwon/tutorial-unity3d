using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Main : MonoBehaviour, Controller.IPlayerActions
{
    public GameObject dino;
    public float speed = 10;
    public Vector3 dir = Vector3.zero;
    private Controller controller;

    void Start()
    {
        controller = new Controller();
        controller.Player.Enable();
        controller.Player.SetCallbacks(this);
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
