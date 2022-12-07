using UnityEngine;

public class GameState : MonoBehaviour
{
    public StateMachine gameStateMachine;
    
    public PlayState gamePlayState = new PlayState();
    public NewWaveState gameNewWaveState = new NewWaveState();
    public GameOverState gameOverState = new GameOverState();

    public GameObject newWaveUI;

    private void Awake()
    {
        gameStateMachine = gameObject.AddComponent<StateMachine>();
    }


    private void Start()
    {
        gameStateMachine.ChangeState(gamePlayState);
    }

    private void Update()
    {
        Debug.Log("GameStateUpdating");
        gameStateMachine.Execute();
    }
}
