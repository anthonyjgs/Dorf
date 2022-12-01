using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{

    [SerializeField] private GameObject goblin;
    [SerializeField] private float launchForce = 10.0f;

    void Update()
    {
        if (Input.GetKeyDown("q")) Spawn();
    }

    // Instantiate a goblin and give it a starting velocity
    void Spawn()
    {
        GameObject newGob = Instantiate<GameObject>(goblin, transform.position, new Quaternion());
        CharacterMovement mover = newGob.GetComponent<CharacterMovement>();
        mover.ApplyKnockback(transform.forward * launchForce);
    }
}
