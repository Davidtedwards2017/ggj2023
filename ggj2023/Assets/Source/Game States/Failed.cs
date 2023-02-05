using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failed : GameState
{
    public GameState gameplayState;

    public GameState creditsState;


    public SimpleEventSO failedEventSO;
    public int failedCount = 0;

    public int maxFailCount = 3;
    
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
    }

    public override void Reset()
    {
        failedCount = 0;
        base.Reset();
    }
}
