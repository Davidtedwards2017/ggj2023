using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Sucess : GameState
{
    public SimpleEventSO successEventSO;
    public GameState creditsState;
    public DialogueController dialogueController;
    public DialogueSequenceSO successDialogueSequence;
    
    public override void Enter()
    {
        base.Enter();
        successEventSO.Raise();
        
        StartCoroutine(SuccessSequence());
    }

    private IEnumerator SuccessSequence()
    {
        yield return dialogueController.RunSequence(successDialogueSequence);
        SetState(creditsState);
    }
}
