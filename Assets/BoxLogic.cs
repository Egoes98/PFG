using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLogic : MonoBehaviour
{
    public Animator anim;
    public DoorAnimationLogic dAL;

    bool unlocking;

    public GameObject clip;

    public void OpenBox()
    {
        unlocking = true;
        anim.SetBool("Unlocking", unlocking);
    }

    void Update()
    {
        if (unlocking)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("acid_use"))
            {
                unlocking = false;
                Destroy(clip);
                dAL.InteractDoor();
            }
        }
    }
}
