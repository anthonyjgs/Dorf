using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawnManager : MonoBehaviour
{
    private GoblinSpawner[] spawners;
    [SerializeField] private float baseTime = 5.0f;
    [SerializeField] private float timeModifier = 0.95f;
    private float timer;

    void Awake(){timer = baseTime;}
    
    void Start()
    {
        spawners = GetComponentsInChildren<GoblinSpawner>();
    }

    // Spawn gobbos faster and faster over time
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            int spawnIndex = Random.Range(0, spawners.Length);
            Debug.Log(spawnIndex);
            spawners[spawnIndex].Spawn();
            baseTime *= timeModifier;
            timer = baseTime;
        }
    }
}
