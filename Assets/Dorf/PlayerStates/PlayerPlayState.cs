using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayState : State
{
    private StateMachine pMachine;
    private GameObject player;
    [SerializeField] private CharacterMovement mover;
    [SerializeField] private CharacterAttacker attacker;
    [SerializeField] private Animator animator;

    // Gets called when this state is initialized
    public override void Enter(StateMachine machine)
    {
        pMachine = machine;
        player = pMachine.gameObject;
        mover = player.GetComponent<CharacterMovement>();
        attacker = player.GetComponent<CharacterAttacker>();
        animator = player.GetComponent<Animator>();
    }

    public override void Execute(StateMachine machine)
    {
        float moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("moveInput", Mathf.Abs(moveInput));
        animator.SetBool("grounded", mover.grounded);
        mover.moveInput = moveInput;
        if (Input.GetButtonDown("Jump")) mover.jumpInput = true;

        // Attack
        if (Input.GetButtonDown("Attack"))
        {
            attacker.UseAttack();
        }

        // If health hits zero, transition to dead state.


        //DEBUG
        if (Input.GetButtonDown("Fire2")) animator.SetBool("isDead", true);
    }

    public override void Exit(StateMachine machine)
    {

    }
}
