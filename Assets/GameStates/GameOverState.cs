using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : State
{
    GameState gameState;
    GoblinSpawnManager goblinSpawnManager;

    public override void Enter(StateMachine stateMachine)
    {
        Time.timeScale = 0.2f;
        gameState = stateMachine.gameObject.GetComponent<GameState>();
        gameState.gameOverUI.SetActive(true);
        goblinSpawnManager = GameObject.Find("GoblinSpawnManager").GetComponent<GoblinSpawnManager>();
        goblinSpawnManager.Stop();
        gameState.audioSource.PlayOneShot(gameState.gameOverClip);
    }

    public override void Execute(StateMachine stateMachine)
    {

    }

    public override void Exit(StateMachine stateMachine)
    {

    }
}
