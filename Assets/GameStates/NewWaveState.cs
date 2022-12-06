using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWaveState : State
{
    State playState = new PlayState();

    public override void Enter(StateMachine stateMachine)
    {
        // Restore player's health and display new wave UI
    }

    public override void Execute(StateMachine stateMachine)
    {
        if (Input.GetButtonDown("attack")) stateMachine.ChangeState(playState);
    }

    public override void Exit(StateMachine stateMachine)
    {

    }
}
