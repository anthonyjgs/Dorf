using UnityEngine;

public class GobStateManager : MonoBehaviour
{
    private GobLiveState liveState = new GobLiveState();
    private StateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = gameObject.GetComponent<StateMachine>();
        stateMachine.ChangeState(liveState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Execute();
    }
}
