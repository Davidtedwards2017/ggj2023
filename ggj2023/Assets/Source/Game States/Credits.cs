using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Credits : GameState
{
    public GameState startupState;
    public TextTyper CreditsTextTyper;
    
    public DialogueEntrySO creditsDialogue;

    public CanvasGroup textCanvasGroup;
    
    public float timeBeforeText = 1.0f;
    public float timeForText = 6.0f;
    public float timeFadeDuration = 2.0f;
    public float timeAfterText = 4.0f;
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(CreditsSequence());
    }

    private IEnumerator CreditsSequence()
    {
        textCanvasGroup.alpha = 1;
        yield return new WaitForSeconds(timeBeforeText);
        yield return CreditsTextTyper.PerformTextTyping(creditsDialogue.text);

        textCanvasGroup.DOFade(0, timeFadeDuration);
        yield return new WaitForSeconds(timeAfterText);
        SetState(startupState);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
