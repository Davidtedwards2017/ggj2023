using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePlay : GameState
{
    public SimpleEventSO ReadyToCalculateEventSO;
    public SimpleEventSO NotReadyToCalculateEventSO;
    public SimpleEventSO OnConfrimSelectionSO;

    public UnityEvent OnReadyToProcessEvent;
    public UnityEvent OnNotReadyToProcessEvent;


    public GameState processingState;
    
    private void OnEnable()
    {
        ReadyToCalculateEventSO.Event.AddListener(ReadyToCalculate);
        NotReadyToCalculateEventSO.Event.AddListener(NotReadyToCalculate);
        OnConfrimSelectionSO.Event.AddListener(OnConfirmSelection);
    }

    private void OnDisable()
    {
        ReadyToCalculateEventSO.Event.RemoveListener(ReadyToCalculate);
        NotReadyToCalculateEventSO.Event.RemoveListener(NotReadyToCalculate);
        OnConfrimSelectionSO.Event.RemoveListener(OnConfirmSelection);
    }

    private void ReadyToCalculate()
    {
        Debug.Log("Ready to Calculate!");
        OnReadyToProcessEvent?.Invoke();
    }
    
    private void NotReadyToCalculate()
    {
        Debug.Log("Not Ready to Calculate!");
        OnNotReadyToProcessEvent?.Invoke();
    }

    private void OnConfirmSelection()
    {
        SetState(processingState);
    }
    
}
