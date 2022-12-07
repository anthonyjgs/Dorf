using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : State
{
    GameObject gobSpawnManager;
    GoblinSpawnManager spawnManagerScript;

    public override void Enter(StateMachine stateMachine)
    {
        Time.timeScale = 1.0f;
        if (gobSpawnManager == null) 
        {
            gobSpawnManager = GameObject.Find("GoblinSpawnManager");
            spawnManagerScript = gobSpawnManager.GetComponent<GoblinSpawnManager>();
        }
        if (spawnManagerScript.active == false) spawnManagerScript.Resume();
    }

    public override void Execute(StateMachine stateMachine)
    {

    }

    public override void Exit(StateMachine stateMachine)
    {

    }
}
