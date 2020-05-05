using UnityEngine;
using System.Collections;

public class PanelControll : MonoBehaviour
{
    Animator animator;
    bool open; //To see if its open ore closed, to open it or close it

    void Start()
    {
        animator = GetComponent<Animator>();
        open = false;
    }

    IEnumerator Open()
    {
        animator.SetBool("Open", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("Open", false);
    }
    IEnumerator Close()
    {
        animator.SetBool("Close", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("Close", false);
    }

    public void OpenClose()
    {
        if (!open)
        {
            open = true;
            StartCoroutine(Open());

        }
        else
        {
            open = false;
            StartCoroutine(Close());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            OpenClose();
        }
    }
}
