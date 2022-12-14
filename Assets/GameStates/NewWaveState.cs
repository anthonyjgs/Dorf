using UnityEngine;
using UnityEngine.UI;

public class NewWaveState : State
{
    GameObject player;
    CharacterHealth playerHealthComp;
    GameObject newWaveUI;
    GameState gameState;

    private ScoreTracker scoreTracker;

    public override void Enter(StateMachine stateMachine)
    {
        Time.timeScale = 0f;
        
        // Restore player's health and grab scoreTracker off of the player
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthComp = player.GetComponent<CharacterHealth>();

        playerHealthComp.health = playerHealthComp.maxHealth;

        scoreTracker = player.GetComponent<ScoreTracker>();

        // Display new wave UI
        newWaveUI = stateMachine.gameObject.GetComponent<GameState>().newWaveUI;
        Text textComponent = newWaveUI.transform.GetChild(2).GetComponent<Text>();
        textComponent.text = ("WAVE: " + scoreTracker.WAVE);
        newWaveUI.SetActive(true);

        // Sound effect
        gameState = stateMachine.gameObject.GetComponent<GameState>();
        gameState.audioSource.PlayOneShot(gameState.newWaveClip);
    }

    public override void Execute(StateMachine stateMachine)
    {
        if (Input.GetButtonDown("Submit"))
        {
            stateMachine.ChangeState(gameState.gamePlayState);
        }
    }

    public override void Exit(StateMachine stateMachine)
    {
        // Hide new wave UI
        newWaveUI.SetActive(false);
    }
}
