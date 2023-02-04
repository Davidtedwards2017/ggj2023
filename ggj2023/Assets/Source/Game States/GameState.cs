using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    public UnityEvent OnEnterEvent;
    public UnityEvent OnExitEvent;
    
    public Animator CanvasAnimator;
    
    public bool Active = false;

    protected void SetState(GameState state)
    {
        GameStateController.Instance.SetState(state);
    }

    public virtual void Enter()
    {
        Debug.Log("Entering State: " + this.GetType().Name);
        Active = true;
        OnEnterEvent?.Invoke();
        if (CanvasAnimator != null) CanvasAnimator.SetBool("Show", true);
    }

    public virtual void Exit()
    {
        Debug.Log("Exiting State: " + this.GetType().Name);
        Active = false;
        OnExitEvent?.Invoke();
        if (CanvasAnimator != null) CanvasAnimator.SetBool("Show", false);
    }
}
