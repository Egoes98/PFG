using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationLogic : MonoBehaviour
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
        animator.SetInteger("State", 1);
        yield return new WaitForSeconds(1);
        animator.SetInteger("State", 2);
        yield return new WaitForSeconds(5);
        CloseDoor();
    }

    IEnumerator Close()
    {
        open = false;
        animator.SetInteger("State", 0);
        yield return new WaitForSeconds(1);
        animator.SetInteger("State", 2);
    }

    public void CloseDoor()
    {
        if (open)
        {
            open = false;
            StartCoroutine(Close());
        }
    }

    public void OpenDoor()
    {
        print("PUERTA");
        if (!open)
        {
            print("ABRE");
            open = true;
            StartCoroutine(Open());

        }
        else if(string.Compare(this.gameObject.name, "01_low") == 0)
        {
            print("CIERRA");
            CloseDoor();
        }
        else
        {
            return;
        }
    }
}
