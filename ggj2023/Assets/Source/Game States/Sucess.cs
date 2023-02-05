using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Sucess : GameState
{
    public SimpleEventSO successEventSO;
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
        base.Enter();
        successEventSO.Raise();
    }
}
