using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float health = 100;
    [SerializeField] private float knockbackDampening = 1.0f;

    public UnityEvent OnDeath;
    public CharacterMovement mover;

    [SerializeField] private AudioSource hurtSource;

    private void Start()
    {
        if (mover == null) mover = gameObject.GetComponent<CharacterMovement>();
    }

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
            force *= (maxHealth / health) * knockbackDampening;
            mover.ApplyKnockback(force);
        }
        // If the object has a rigidbody component instead
        else if (gameObject.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(force);
        }
    }
}
