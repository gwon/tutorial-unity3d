using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boo : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        animator.SetBool("jump", true);
    }

    public void Stand()
    {
        animator.SetBool("jump", true);
    }
}
