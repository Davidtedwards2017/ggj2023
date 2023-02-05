using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Processing : GameState
{
    public GameState failedState;
    public GameState successState;

    public float processingTime = 2.0f;
    public CheckSolution solutionChecker;

    public override void Enter()
    {
        base.Enter();
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
