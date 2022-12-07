using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : State
{

    public override void Enter(StateMachine stateMachine)
    {
        Time.timeScale = 1.0f;
    }

    public override void Execute(StateMachine stateMachine)
    {

    }

    public override void Exit(StateMachine stateMachine)
    {

    }
}
