using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiCamera : MonoBehaviour
{
    public Animator animator;
    public bool battle, view;
    private void Update()
    {
        if (battle)
        {
            battle = false;
            BattleCam();
        }
        else if (view)
        {
            view = false;
            ViewCam();
        }
    }
    public void BattleCam()
    {
        animator.SetTrigger("Battle");
    }
    public void ViewCam()
    {
        animator.SetTrigger("View");
    }
}


