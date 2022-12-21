using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public Animator animator;
    bool start;
    public void StartAnimasi()
    {
        if (!start)
        {
            start = true;
            animator.SetBool("Start", true);
        }
        else if (start)
        {
            start = false;
            animator.SetBool("Start", false);
        }
        AudioManager.instance.ButtonUISfx();
    }

    public void ExitAnimasi()
    {
        if (start)
        {
            start = false;
            animator.SetBool("Start", false);
        }


    }
}
