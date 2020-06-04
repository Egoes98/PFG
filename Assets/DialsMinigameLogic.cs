using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialsMinigameLogic : MonoBehaviour
{
    public DialLogic d1;
    public DialLogic d2;
    public DialLogic d3;

    public int s1;
    public int s2;
    public int s3;

    public Animator dialsAnim;

    bool solved;

    public AudioSource aS_wrong;
    public AudioSource aS_correct;

    public void Check()
    {
        if (solved) return;
        int inD1 = d1.getState();
        int inD2 = d2.getState();
        int inD3 = d3.getState();

        if(inD1 == s1 && inD2 == s2 && inD3 == s3)
        {
            solved = true;
            dialsAnim.SetBool("Move",true);
            aS_correct.Play();
        }
        else
        {
            aS_wrong.Play();
        }
    }

}
