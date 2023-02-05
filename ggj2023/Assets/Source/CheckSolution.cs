using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckSolution : MonoBehaviour
{
    public SimpleEventSO ReadyToCalculateEventSO;
    public SimpleEventSO NotReadyToCalculateEventSO;
    public PortraitEventSO PortraitPlacedEventSO;
    public PortraitEventSO PortraitGrabbedEventSO;
    
    public ResultSlot leftParentSlot;
    public List<ResultSlot> leftGrandParentSlots;
    
    public ResultSlot rightParentSlot;
    public List<ResultSlot> rightGrandParentSlots;

    public bool allSlotsPlaced;
    public bool correctSolution;


    private void OnEnable()
    {
        PortraitPlacedEventSO.Event.AddListener(OnPortraitPlaced);
        PortraitGrabbedEventSO.Event.AddListener(OnPortraitGrabbed);
    }

    private void OnDisable()
    {
        PortraitPlacedEventSO.Event.RemoveListener(OnPortraitPlaced);
        PortraitGrabbedEventSO.Event.RemoveListener(OnPortraitGrabbed);
    }

    void OnPortraitPlaced(Portrait portrait)
    {
        allSlotsPlaced = true;
        if (!leftParentSlot.IsFilled()) allSlotsPlaced = false;
        if (!rightParentSlot.IsFilled()) allSlotsPlaced = false;
        if (leftGrandParentSlots.Any(e => !e.IsFilled())) allSlotsPlaced = false;
        if (rightGrandParentSlots.Any(e => !e.IsFilled())) allSlotsPlaced = false;
        
        if (allSlotsPlaced)
        {
            ReadyToCalculateEventSO.Raise();
        }
    }

    void OnPortraitGrabbed(Portrait portrait)
    {
        if (allSlotsPlaced)
        {
            allSlotsPlaced = false;
            NotReadyToCalculateEventSO.Raise();
        }
    }

    // Update is called once per frame
    void Update()
    {

        // if (allSlotsPlaced)
        // {
        //     correctSolution = ValidateSolution();
        // }
    }

    public bool ValidateSolution()
    {
        if (!leftParentSlot.ScanTree())
        {
            return false;
        }
        
        if (!rightParentSlot.ScanTree())
        {
            return false;
        }

        return true;
        
           
        
        return false;
    }
}
