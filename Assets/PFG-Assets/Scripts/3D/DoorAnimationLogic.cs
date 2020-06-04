using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationLogic : MonoBehaviour
{
    Animator animator;
    bool open;
    public bool locked;
    public bool closeOverTime;
    public bool dontClose;

    void Start()
    {
        animator = GetComponent<Animator>();
        open = false;
        dontClose = false;
    }

    IEnumerator CloseOverTime()
    {
        yield return new WaitForSeconds(5);
        open = false;
        animator.SetBool("Open", open);
    }

    public void CloseDoor()
    {
        if (open)
        {
            open = false;
            animator.SetBool("Open", open);
        }
    }


    public void InteractDoor()
    {
        if (locked) return;
        if (!open)
        {
            open = true;
            animator.SetBool("Open", open);
            if (closeOverTime) StartCoroutine(CloseOverTime());

        }
        else if(dontClose)
        {
            return;
        }
        else
        {
            open = false;
            animator.SetBool("Open", open);
        }
    }

    public void Unlock()
    {
        locked = false;
    }
}
