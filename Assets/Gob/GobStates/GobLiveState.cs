/*
This script essentially handles goblin AI when it is alive.


*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobLiveState : State
{
    private StateMachine stateMachine;
    private GameObject goblin;
    private GameObject target;

    private bool stunned = false;
    [SerializeField] private float attackRange = 1.0f;

    [SerializeField] private CharacterMovement mover;
    [SerializeField] private CharacterAttacker attacker;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterHealth health;

        // Gets called when this state is initialized
    public override void Enter(StateMachine machine)
    {
        stateMachine = machine;
        goblin = machine.gameObject;
        mover = goblin.GetComponent<CharacterMovement>();
        attacker = goblin.GetComponent<CharacterAttacker>();
        animator = goblin.GetComponent<Animator>();
        health = goblin.GetComponent<CharacterHealth>();
        target = GameObject.Find("Player");
    }

    public override void Execute(StateMachine machine)
    {
        stunned = health.stunned;
        animator.SetBool("isHurting", stunned);
        if (mover.grounded && !stunned) {
            // Calculate movement input and apply
            float targetDistanceX = target.transform.position.x - goblin.transform.position.x;
            float moveInput;
            if (Mathf.Abs(targetDistanceX) > attackRange)
            {
                moveInput = Mathf.Clamp(targetDistanceX, -1.0f, 1.0f);
            }
            else
            {
                moveInput = 0;
                // Attack!
                attacker.UseAttack();
            }
            animator.SetFloat("moveSpeed", Mathf.Abs(moveInput));
            mover.ApplyInputs(moveInput);
        }
    }

    public override void Exit(StateMachine machine)
    {
        throw new System.NotImplementedException();
    }
}
