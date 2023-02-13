using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class Failed : GameState
{
    public GameState gameplayState;

    public GameState creditsState;

    public SimpleEventSO failedEventSO;
    public int failedCount = 0;

    public int maxFailCount = 3;


    public AudioClip gameoverMusic;
    public SoundEffectData SFX;
    
    public SimpleEventSO returnToGameplayEventSO;
    public SimpleEventSO gameoverEventSO;

    public DialogueController dialogueController;

    public List<DialogueSequenceSO> failDialogueSequence;
    public DialogueSequenceSO gameoverGameDialogueSequence;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Enter()
    {
        failedEventSO.Raise();
        base.Enter();

        SFX.PlaySfx();
        failedCount++;
        if (failedCount >= maxFailCount)
        {
            StartCoroutine(GameOverSequence());
        }
        else
        {
            StartCoroutine(ReturnToGameplaySequence());
        }
    }

    private IEnumerator ReturnToGameplaySequence()
    {
        returnToGameplayEventSO.Raise();
        yield return dialogueController.RunSequence(failDialogueSequence[failedCount-1]);
        SetState(gameplayState);
    }

    private IEnumerator GameOverSequence()
    {
        gameoverEventSO.Raise();
        yield return dialogueController.RunSequence(gameoverGameDialogueSequence);
        SetState(creditsState);
    }
    
    public override void Reset()
    {
        failedCount = 0;
        base.Reset();
    }
}
