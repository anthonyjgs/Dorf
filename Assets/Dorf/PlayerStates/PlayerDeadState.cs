using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : State
{
    private StateMachine pMachine;
    private GameObject player;
    private CharacterMovement mover;
    private Animator animator;


    // Gets called when this state is initialized
    public override void Enter(StateMachine machine)
    {
        pMachine = machine;
        player = pMachine.gameObject;
        mover = player.GetComponent<CharacterMovement>();
        animator = player.GetComponent<Animator>();

        animator.SetBool("isDead", true);
        Time.timeScale = 0.1f;
    }

    public override void Execute(StateMachine machine)
    {

    }

    public override void Exit(StateMachine machine)
    {

    }
}
