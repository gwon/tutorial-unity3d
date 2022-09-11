using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Main : MonoBehaviour
{
    public GameObject dino;
    public float speed = 10;
    public Vector3 dir = Vector3.zero;
    void Start()
    {

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

    void Update()
    {
        Vector3 next = dino.transform.position + dir * Time.deltaTime * speed;
        dino.transform.position = next;
    }
}
