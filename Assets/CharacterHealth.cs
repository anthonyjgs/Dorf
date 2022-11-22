using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    public UnityEvent OnDeath;
    public CharacterMovement mover;

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0) OnDeath?.Invoke();
    }

    // TODO ##################################################
    public void ApplyKnockback(float force, Vector3 direction)
    {
        if (mover != null)
        {

        }
        else if (gameObject.TryGetComponent(out Rigidbody rb))
        {

        }
    }
}
