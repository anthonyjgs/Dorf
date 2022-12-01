using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobOutBounds : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    
    public void Die()
    {
        Instantiate<GameObject>(deathEffect, transform);
        Destroy(gameObject);
    }
}
