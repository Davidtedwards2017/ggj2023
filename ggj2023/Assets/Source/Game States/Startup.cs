using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : GameState
{
    public SimpleEventSO clearAllEventSO;
    
    public GameState NextState;
    public float HoldTime = 2.0f;

    public AudioClip musicTrack;
    public override void Enter()
    {
        base.Enter();
        clearAllEventSO.Raise();
        MusicController.Instance.Play(musicTrack);
        StartCoroutine(TransitionToNextState());
    }

    IEnumerator TransitionToNextState()
    {
        yield return new WaitForSeconds(HoldTime);
        SetState(NextState);
    }
}
