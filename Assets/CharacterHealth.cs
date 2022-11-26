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

    [SerializeField] private AudioSource hurtSource;

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (hurtSource != null) hurtSource.Play();
        if (health <= 0) OnDeath?.Invoke();
    }

    // TODO ##################################################
    public void ApplyKnockback(Vector3 force)
    {
        // If the object has a mover component
        if (mover != null)
        {
            mover.ApplyKnockback(force);
        }
        // If the object has a rigidbody component instead
        else if (gameObject.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(force);
        }
    }
}
