using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDoor : MonoBehaviour
{
    Animator animator;
    bool open;

    void Start()
    {
        animator = GetComponent<Animator>();
        open = false;
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(1);
        animator.SetInteger("DoorControll", 1);
        yield return new WaitForSeconds(1);
        animator.SetInteger("DoorControll", 0);
        yield return new WaitForSeconds(10);
        StartCoroutine(Close());
    }

    IEnumerator Close()
    {
        animator.SetInteger("DoorControll", 2);
        yield return new WaitForSeconds(1);
        animator.SetInteger("DoorControll", 0);
    }

    public void CloseDoor()
    {
        if (open)
        {
            StartCoroutine(Close());
        }
    }

    public void OpenDoor()
    {
        if (!open)
        {
            open = true;
            StartCoroutine(Open());

        }
        else
        {
            return;
        }
    }

    void Update()
    {
        if (animator.GetInteger("DoorControll") == 2)
        {
            open = false;
        }
    }
}
