using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeVrLogic : MonoBehaviour
{
    [Header("Password Settings")]
    public string password;
    public int passwordLong;

    [Header("References")]
    public ManageInput mI;
    public AudioSource correct;
    public AudioSource incorrect;
    public Animator anim;

    string input;
    bool open;

    void Start()
    {
        open = false;
    }

    public void ButtonClicked(string i)
    {
        if (open) return;
        mI.ManageSlots(i);
        input = input + i;
        if (input.Length == passwordLong)
        {
            open = true;
            StartCoroutine("waitForCheck");
        }
    }

    IEnumerator waitForCheck()
    {
        yield return new WaitForSeconds(1);
        Check();
    }

    void Check()
    {
        if (string.Compare(password, input) == 0)
        {
            correct.Play(0);
            anim.SetBool("Open", true);
        }
        else
        {
            incorrect.Play(0);
            mI.Clear();
            open = false;
        }
    }
}
