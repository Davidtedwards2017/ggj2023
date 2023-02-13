using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitDisplayController : MonoBehaviour
{
    public Animator animator;

    public TraitDisplayer displayer;

    public PortraitEventSO portaitGrabbedEventSO;
    public PortraitEventSO portaitLetGoEventSO;


    private void OnEnable()
    {
        portaitGrabbedEventSO.Event.AddListener(OnPortraitGrabbed);
        portaitLetGoEventSO.Event.AddListener(OnPortraitLetGo);
    }

    private void OnDisable()
    {
        portaitGrabbedEventSO.Event.RemoveListener(OnPortraitGrabbed);
        portaitLetGoEventSO.Event.RemoveListener(OnPortraitLetGo);
    }

    private void OnPortraitGrabbed(Portrait portrait)
    {
        displayer.Set(portrait.portraitMetadata.name, portrait.portraitMetadata.traits);
        animator.SetBool("show", true);
    }
    
    private void OnPortraitLetGo(Portrait portrait)
    {
        animator.SetBool("show", false);
    }
}
