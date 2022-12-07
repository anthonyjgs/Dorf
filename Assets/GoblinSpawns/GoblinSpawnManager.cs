using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawnManager : MonoBehaviour
{
    private GoblinSpawner[] spawners;
    [SerializeField] private float baseTime = 4.0f;
    [SerializeField] private float timeModifier = 0.8f;
    private float timer;
    private int gobsThisWave;
    private bool active = true;

    private ScoreTracker scoreTracker;

    void Awake(){timer = baseTime;}
    
    void Start()
    {
        spawners = GetComponentsInChildren<GoblinSpawner>();
        scoreTracker = GameObject.Find("Player").GetComponent<ScoreTracker>();
        gobsThisWave = scoreTracker.SCORETONEXTWAVE;
    }

    // Spawn gobbos faster and faster over time
    void Update()
    {
        if (active)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && gobsThisWave > 0)
            {
                int spawnIndex = Random.Range(0, spawners.Length);
                spawners[spawnIndex].Spawn();
                timer = baseTime;
                gobsThisWave -= 1;
                if (gobsThisWave <= 0) this.Stop();
            }
        }
    }

    // Stops spawning gobbos
    public void Stop()
    {
        active = false;
    }

    // Called from the gameState class
    public void Resume()
    {
        gobsThisWave = scoreTracker.SCORETONEXTWAVE - scoreTracker.GetScore();
        baseTime *= timeModifier;
        timer = baseTime;
        active = true;
    }
}
