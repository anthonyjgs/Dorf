using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutBounds : MonoBehaviour
{
    PlayerDeadState deadState = new PlayerDeadState();
    public void gotoDeadState()
    {
        StateMachine stateMachine = gameObject.GetComponent<StateMachine>();
        if (stateMachine.currentState != deadState);
        {
            stateMachine.ChangeState(deadState);
        }
    }
}
