using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : GameState
{
    public GameState NextState;
    public float HoldTime = 2.0f;
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(TransitionToNextState());
    }

    IEnumerator TransitionToNextState()
    {
        yield return new WaitForSeconds(HoldTime);
        SetState(NextState);
    }
}
