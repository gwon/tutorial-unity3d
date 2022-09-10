using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject dino;
    public float speed = 10;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 next = dino.transform.position;
            next.x -= speed * Time.deltaTime;
            dino.transform.position = next;

            Vector3 scale = dino.transform.localScale;
            scale.x = -1;
            dino.transform.localScale = scale;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 next = dino.transform.position;
            next.x += speed * Time.deltaTime;
            dino.transform.position = next;

            Vector3 scale = dino.transform.localScale;
            scale.x = 1;
            dino.transform.localScale = scale;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 next = dino.transform.position;
            next.y -= speed * Time.deltaTime;
            dino.transform.position = next;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 next = dino.transform.position;
            next.y += speed * Time.deltaTime;
            dino.transform.position = next;
        }
    }
}
