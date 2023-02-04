using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : GameState
{
    public GameState GameplayState;
    

    // Update is called once per frame
    void Update()
    {
        if (!Active) return;
        
        if (Input.anyKeyDown)
        {
            SetState(GameplayState);
        }
    }
}
