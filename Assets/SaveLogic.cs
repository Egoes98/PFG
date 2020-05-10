using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLogic : MonoBehaviour
{
    [Header("Password Settings")]
    public string password;
    public int passwordLong;

    [Header("References")]
    public GameObject logic;
    GameObject player;
    public Animator anim;
    public ManageInput mI;
    public AudioSource correct;
    public AudioSource incorrect;
   
    string input;
    bool open;
    bool use;

    void Start()
    {
        open = false;
        player = GameObject.FindGameObjectWithTag("Player");
        use = false;
    }

    void FixedUpdate()
    {
        if (use && Input.GetKeyDown(KeyCode.E))
        {
            logic.SetActive(false);
            player.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            use = false;
        }
    }

    public void UseSafe()
    {
        if (use||open) return;
        player.SetActive(false);
        logic.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        use = true;
    }

    public void ButtonClicked(string i)
    {
        if (open) return;
        mI.ManageSlots(i);
        input = input + i;
        if (input.Length == passwordLong){
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
            logic.SetActive(false);
            player.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            anim.SetBool("Open",true);
        }
        else
        {
            incorrect.Play(0);
            mI.Clear();
            input = "";
            open = false;
        }
    }
}
