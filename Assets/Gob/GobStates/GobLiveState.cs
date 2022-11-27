using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobLiveState : State
{
    private StateMachine stateMachine;
    private GameObject goblin;
    [SerializeField] private CharacterMovement mover;
    [SerializeField] private CharacterAttacker attacker;
    [SerializeField] private Animator animator;

        // Gets called when this state is initialized
    public override void Enter(StateMachine machine)
    {
        stateMachine = machine;
        goblin = stateMachine.gameObject;
        mover = goblin.GetComponent<CharacterMovement>();
        attacker = goblin.GetComponent<CharacterAttacker>();
        animator = goblin.GetComponent<Animator>();
    }

    public override void Execute(StateMachine machine)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit(StateMachine machine)
    {
        throw new System.NotImplementedException();
    }
}
