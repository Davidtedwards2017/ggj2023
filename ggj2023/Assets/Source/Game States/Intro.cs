using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : GameState
{
    public GameState gameplayState;
    public DialogueController dialogueController;
    public DialogueSequenceSO introDialogueSequence;
    
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(introSequence());
    }
    
    private IEnumerator introSequence()
    {
        yield return dialogueController.RunSequence(introDialogueSequence);
        SetState(gameplayState);
    }
}
