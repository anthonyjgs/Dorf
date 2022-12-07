using UnityEngine;

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
        Debug.Log("PlayerStateUpdating");
        stateMachine.Execute();
    }
}
