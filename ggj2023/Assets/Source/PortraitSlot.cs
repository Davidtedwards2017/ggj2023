using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitSlot : MonoBehaviour
{
    public PortraitEventSO portraitDestroyedSO;
    public PortraitEventSO portraitPlacedEventSO;
    public PortraitEventSO portraitedGrabbebEvent;
    public Portrait attachedPortrait;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        portraitedGrabbebEvent.Event.AddListener(OnPortraitGrabbed);
        portraitDestroyedSO.Event.AddListener(OnPortraitDestroyed);
    }

    private void OnDisable()
    {
        portraitedGrabbebEvent.Event.RemoveListener(OnPortraitGrabbed);
        portraitDestroyedSO.Event.RemoveListener(OnPortraitDestroyed);
    }

    private void OnPortraitGrabbed(Portrait portrait)
    {
        if (attachedPortrait == portrait)
        {
            Debug.Log(gameObject.name + " detaching " + attachedPortrait.name);
            attachedPortrait = null;
        }
    }

    private void OnPortraitDestroyed(Portrait portrait)
    {
        if (attachedPortrait == portrait)
        {
            attachedPortrait = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attachedPortrait)
        {
            Vector3 newPos = Vector3.MoveTowards(
                attachedPortrait.transform.position,
                transform.position, 
                attachedPortrait.moveSpeed * Time.deltaTime);

            attachedPortrait.transform.position = newPos;
        }
    }

    public bool AlreadyOccupied()
    {
        return attachedPortrait != null;
    }


    public void EjectOccupied()
    {
        // attachedPortrait.transform.SetParent(null);
        attachedPortrait.PutBackInCaseFile();
        attachedPortrait = null;
    }
    
    public void Attach(Portrait portrait)
    {
        attachedPortrait = portrait;
        // attachedPortrait.transform.SetParent(transform);
        // attachedPortrait.MoveToSlot(this);
        portraitPlacedEventSO.Raise(attachedPortrait);
    }
}
