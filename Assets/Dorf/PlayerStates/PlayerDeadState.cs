using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : State
{
    private StateMachine pMachine;
    private GameObject player;
    private CharacterMovement mover;

    // Gets called when this state is initialized
    public override void Enter(StateMachine machine)
    {
        this.pMachine = machine;
        this.player = pMachine.gameObject;
        this.mover = player.GetComponent<CharacterMovement>();
    }

    public override void Execute(StateMachine machine)
    {

    }

    public override void Exit(StateMachine machine)
    {

    }
}
