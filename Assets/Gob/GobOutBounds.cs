using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobOutBounds : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    
    public void Die()
    {
        Vector3 pos = transform.position;
        // TODO -- MAKE THIS BASED ON Direction of boundary hit!
        CharacterMovement mover = GetComponent<CharacterMovement>();
        Quaternion rot = Quaternion.LookRotation(mover.getVelocity());
        Instantiate<GameObject>(deathEffect, pos, rot);

        // Increment the player's score
        ScoreTracker.AddScore(1);
        Destroy(gameObject);
    }
}
