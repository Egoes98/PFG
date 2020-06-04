using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetLogic : MonoBehaviour
{
    public DoorAnimationLogic dAL_l;
    public DoorAnimationLogic dAL_r;
    public Animator keyAnim;

    public GameObject lock_obj;

    bool unlocking;

    public void UnlockOpenDoors()
    {
        unlocking = true;
        keyAnim.SetBool("Use",unlocking);
    }

    public void Update()
    {
        if (unlocking)
        {
            if (keyAnim.GetCurrentAnimatorStateInfo(0).IsName("key_use"))
            {
                unlocking = false;
                Destroy(lock_obj);
                dAL_l.InteractDoor();
                dAL_r.InteractDoor();
            }
        }
    }
}
