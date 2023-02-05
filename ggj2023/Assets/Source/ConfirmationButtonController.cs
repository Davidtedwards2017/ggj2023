using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationButtonController : MonoBehaviour
{
    public Animator animator;

    public SimpleEventSO confirmationSelectedEventSO;
    
    public void OnConfirmationButtonClick()
    {
        confirmationSelectedEventSO.Raise();
    }

    public void SetVisible(bool visible)
    {
        animator.SetBool("show", visible);
    }
}
