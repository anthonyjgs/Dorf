using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerPlayState playState = new PlayerPlayState();
    private StateMachine stateMachine;

    private void Start()
    {
        stateMachine = gameObject.GetComponent<StateMachine>();
        stateMachine.ChangeState(playState);
    }

    private void Update()
    {
        stateMachine.Execute();
    }
}
