using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Utilites;

public class Sucess : GameState
{
    public SimpleEventSO successEventSO;
    public GameState creditsState;
    public DialogueController dialogueController;
    public DialogueSequenceSO successDialogueSequence;
    public SoundEffectData SFX;
    
    public override void Enter()
    {
        base.Enter();
        SFX.PlaySfx();
        successEventSO.Raise();
        
        StartCoroutine(SuccessSequence());
    }

    private IEnumerator SuccessSequence()
    {
        yield return dialogueController.RunSequence(successDialogueSequence);
        SetState(creditsState);
    }
}
