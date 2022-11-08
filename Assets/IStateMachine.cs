// Basic state machine class that allows handling states when each is their own class.
// This class can be used anywhere that needs to handle states

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates an interface, which holds only abstract functions
// IState is the state interface, allowing us to create IState objects (like a play state, or a game over state)
public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}

// Implements StateMachine with the IState interface, requiring StateMachine to implement definitions for the functions within IState
public class StateMachine : MonoBehaviour
{
    // Create an empty variable to hold our current state
    IState currentState;
    
    // Create an empty list for using a stateStack NOT YET IMPLEMENTED
    // List<IState> stateStack;
    public void ChangeState(IState newState)
    {
        if (currentState != null) currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null) currentState.Execute();
    }
}
