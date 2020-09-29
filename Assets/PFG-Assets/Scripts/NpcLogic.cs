using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLogic : MonoBehaviour
{
    public EnableObject enableObj;
    public Animator anim;

    public void GiveRoomCard()
    {
        anim.SetBool("GiveCard", true);
    }

    public void Enable()
    {
        enableObj.enable();
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("givecard_animation"))
        {
            anim.SetBool("GiveCard", false);
        }
    }
}
