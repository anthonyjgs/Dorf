using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutBounds : MonoBehaviour
{
    PlayerDeadState deadState = new PlayerDeadState();
    private bool isDead = false;
    public void gotoDeadState()
    {
        if (isDead == false)
        {
            isDead = true;
            StateMachine stateMachine = gameObject.GetComponent<StateMachine>();
            stateMachine.ChangeState(deadState);
        }
    }
}
