using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : State
{
    private StateMachine pMachine;
    private GameObject player;
    private CharacterMovement mover;
    private Animator animator;

    private GameState gameState;

    // Gets called when this state is initialized
    public override void Enter(StateMachine machine)
    {
        pMachine = machine;
        player = pMachine.gameObject;
        mover = player.GetComponent<CharacterMovement>();
        animator = player.GetComponent<Animator>();

        animator.SetBool("isDead", true);

        gameState = GameObject.Find("GameStateManager").GetComponent<GameState>();
        gameState.gameStateMachine.ChangeState(gameState.gameOverState);
    }

    public override void Execute(StateMachine machine)
    {

    }

    public override void Exit(StateMachine machine)
    {

    }
}
