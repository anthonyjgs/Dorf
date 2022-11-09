using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayState : State
{
    private StateMachine pMachine;
    private GameObject player;
    private CharacterMovement mover;
    private CharacterAttacker attacker;

    // Gets called when this state is initialized
    public override void Enter(StateMachine machine)
    {
        pMachine = machine;
        player = pMachine.gameObject;
        mover = player.GetComponent<CharacterMovement>();
    }

    public override void Execute(StateMachine machine)
    {
        mover.moveInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump")) mover.jumpInput = true;
    }

    public override void Exit(StateMachine machine)
    {

    }
}
