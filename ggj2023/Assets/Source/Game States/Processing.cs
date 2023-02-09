using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class Processing : GameState
{
    public SoundEffectData SFX;
    public GameState failedState;
    public GameState successState;

    public float processingTime = 2.0f;
    public CheckSolution solutionChecker;

    public override void Enter()
    {
        base.Enter();
        SFX.PlaySfx();
        StartCoroutine(processingSequence());
    }

    private IEnumerator processingSequence()
    {
        yield return new WaitForSeconds(processingTime);
        bool result = solutionChecker.ValidateSolution();
        if (result)
        {
            SetState(successState);
        }
        else
        {
            SetState(failedState);
        }
    }
}
