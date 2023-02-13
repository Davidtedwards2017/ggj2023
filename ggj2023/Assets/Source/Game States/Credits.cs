using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Credits : GameState
{
    public GameState startupState;
    public TextTyper CreditsTextTyper;
    
    public DialogueEntrySO creditsDialogue;

    public CanvasGroup textCanvasGroup;
    
    public AudioClip musicTrack;
    
    
    public float timeBeforeText = 1.0f;
    public float timeForText = 6.0f;
    public float timeFadeDuration = 2.0f;
    public float timeAfterText = 4.0f;

    public SimpleEventSO successEventSO;
    public SimpleEventSO failedEventSO;
    
    public UnityEvent OnWinEvent;
    public UnityEvent OnLoseEvent;

    public bool gameWon = true;

    private void OnEnable()
    {
        successEventSO.Event.AddListener(OnSuccess);
        failedEventSO.Event.AddListener(OnFail);
    }

    private void OnDisable()
    {
        successEventSO.Event.RemoveListener(OnSuccess);
        failedEventSO.Event.RemoveListener(OnFail);
    }

    private void OnSuccess()
    {
        gameWon = true;
    }


    private void OnFail()
    {
        gameWon = false;
    }

    public override void Enter()
    {
        MusicController.Instance.Play(musicTrack);
        base.Enter();
        StartCoroutine(CreditsSequence());
    }

    private IEnumerator CreditsSequence()
    {
        if (gameWon)
        {
            OnWinEvent?.Invoke();
        }
        else
        {
            OnLoseEvent?.Invoke();
        }
        
        textCanvasGroup.alpha = 1;
        yield return new WaitForSeconds(timeBeforeText);
        
        StartCoroutine(CreditsTextTyper.PerformTextTyping(creditsDialogue.text));
        yield return new WaitForSeconds(timeAfterText);
        
        textCanvasGroup.DOFade(0, timeFadeDuration);
        yield return new WaitForSeconds(timeAfterText);
        SetState(startupState);
    }


    public override void Exit()
    {
        MusicController.Instance.Play(null);
        base.Exit();
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
