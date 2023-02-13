using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateController : Singleton<GameStateController>
{
    private GameState m_currentState;

    public GameState StartingState;
    
    // Start is called before the first frame update
    void Start()
    {
        SetState(StartingState);
    }
    
    public void SetState(GameState state)
    {
        if (m_currentState) m_currentState.Exit();
        
        m_currentState = state;
        if (m_currentState) m_currentState.Enter();
    }

    public void Reset()
    {
        foreach (var gameState in GetComponentsInChildren<GameState>(false))
        {
            gameState.Reset();
        }
    }
}
