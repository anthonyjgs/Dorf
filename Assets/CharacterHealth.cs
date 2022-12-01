using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float health = 100;
    [SerializeField] private float knockbackDampening = 1.0f;

    [SerializeField] private bool isStunnable = false;
    [SerializeField] private float stunTime = 0.5f;
    private float stunTimer = 0.0f;
    public bool stunned = false;
    public UnityEvent OnDeath;
    public CharacterMovement mover;

    [SerializeField] private AudioSource hurtSource;
    [SerializeField] private AudioSource powerHitSource;

    private void Awake()
    {
        if (mover == null) mover = gameObject.GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0) stunned = false;
        }
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (hurtSource != null) hurtSource.Play();
        if (health <= 0) OnDeath?.Invoke();
        else if (isStunnable) Stun();
    }

    // TODO ##################################################
    public void ApplyKnockback(Vector3 force)
    {
        // If the object has a mover component
        if (mover != null)
        {
            force *= ((maxHealth + 1) - health)  / knockbackDampening;
            mover.ApplyKnockback(force);
            mover.grounded = false;

            Debug.Log(force.magnitude);
            // If it's particularly strong, play the powerhit sound
            if (powerHitSource && force.magnitude > 20)
            {
                powerHitSource.Play();
            }
        }
        // If the object has a rigidbody component instead
        else if (gameObject.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(force);
        }
    }

    private void Stun()
    {
        stunned = true;
        stunTimer = stunTime;
    }
}
