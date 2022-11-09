// Basic state machine class that allows handling states when each is their own class.
// This class can be used anywhere that needs to handle states

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates an interface, which holds only abstract functions
// IState is the state interface, allowing us to create IState objects (like a play state, or a game over state)
public abstract class State
{
    public abstract void Enter(StateMachine machine);
    public abstract void Execute(StateMachine machine);
    public abstract void Exit(StateMachine machine);
}

// Implements StateMachine with the IState interface, requiring StateMachine to implement definitions for the functions within IState
public class StateMachine : MonoBehaviour
{
    // Create an empty variable to hold our current state
    private State currentState;

    // Create an empty list for using a stateStack NOT YET IMPLEMENTED
    // List<IState> stateStack;

    public void ChangeState(State newState)
    {
        if (currentState != null) currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    public void Update()
    {
        if (currentState != null) currentState.Execute(this);
    }
}
