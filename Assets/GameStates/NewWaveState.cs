using UnityEngine;
using UnityEngine.UI;

public class NewWaveState : State
{
    GameObject player;
    CharacterHealth playerHealthComp;
    GameObject newWaveUI;

    public override void Enter(StateMachine stateMachine)
    {
        Time.timeScale = 0;
        
        // Restore player's health
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthComp = player.GetComponent<CharacterHealth>();

        playerHealthComp.health = playerHealthComp.maxHealth;

        // Display new wave UI
        newWaveUI = stateMachine.gameObject.GetComponent<GameState>().newWaveUI;
        Text textComponent = newWaveUI.transform.GetChild(2).GetComponent<Text>();
        textComponent.text = ("WAVE: " + ScoreTracker.WAVE);
        newWaveUI.SetActive(true);
    }

    public override void Execute(StateMachine stateMachine)
    {
        Debug.Log("New Wave State Execute is called");
        if (Input.GetButtonDown("Attack"))
        {
            Debug.Log("Input Received!");
            stateMachine.ChangeState(stateMachine.gameObject.GetComponent<GameState>().gamePlayState);
        }
    }

    public override void Exit(StateMachine stateMachine)
    {
        // Hide new wave UI
        newWaveUI.SetActive(false);
    }
}
