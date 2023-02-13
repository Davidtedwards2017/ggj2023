using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using Utilites;

public class MouseGrabber : MonoBehaviour
{
    public PortraitEventSO portraitGrabbedEventSO;
    public PortraitEventSO portraitLetGoEventSO;
    private Portrait selectedPortrait;

    public SoundEffectData grabbedSFX;
    public SoundEffectData pinSFX;
    private float rayDistance = 100;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!selectedPortrait)
            {
                GameObject draggable = CastRay("drag");
                if (draggable)
                {
                    selectedPortrait = draggable.GetComponent<Portrait>();
                    if (selectedPortrait)
                    {
                        selectedPortrait.Grab();
                        grabbedSFX.PlaySfx();
                        portraitGrabbedEventSO.Raise(selectedPortrait);
                        Cursor.visible = false;
                    }
                }
            }
        }
        else
        {
            if (selectedPortrait)
            {
                GameObject slot = CastRay("slot");
                if (slot)
                {
                    PortraitSlot portraitSlot = slot.GetComponent<PortraitSlot>();
                    selectedPortrait.LetGo();
                    portraitLetGoEventSO.Raise(selectedPortrait);
                    if (portraitSlot.AlreadyOccupied())
                    {
                        portraitSlot.EjectOccupied();
                    }

                    pinSFX.PlaySfx();
                    portraitSlot.Attach(selectedPortrait);
                }
                else
                {
                    selectedPortrait.PutBackInCaseFile();
                    portraitLetGoEventSO.Raise(selectedPortrait);
                    selectedPortrait.LetGo();
                }
                
                selectedPortrait = null;
                Cursor.visible = true;
            }
        }

        if (selectedPortrait)
        {
            Vector3 position = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(selectedPortrait.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedPortrait.DragPosition(new Vector3(worldPosition.x, worldPosition.y, -0.25f));
        }
        
        
    }

    private GameObject CastRay(string tag)
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit[] hits = Physics.RaycastAll(ray, rayDistance, layerMask);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag(tag))
            {
                return hit.collider.gameObject;
            }
        }

        return null;
    }
}
