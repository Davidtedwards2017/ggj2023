using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAnimationController : MonoBehaviour
{
    public Animator animator;


    public void idle()
    {
        animator.SetTrigger("idle");   
    }

    public void processing()
    {
        animator.SetTrigger("processing");
    }

    public void success()
    {
        animator.SetTrigger("success");
    }

    public void fail()
    {
        animator.SetTrigger("fail");
    }

}
