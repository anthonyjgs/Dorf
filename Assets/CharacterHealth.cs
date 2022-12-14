using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100;
    [SerializeField] public float health = 100;
    [SerializeField] private float knockbackMultiplier = 1.0f;

    [SerializeField] private bool isStunnable = false;
    [SerializeField] private float stunTime = 0.5f;
    private float stunTimer = 0.0f;
    public bool stunned = false;
    public CharacterMovement mover;

    public float powerHitThresh = 10;

    [SerializeField] private AudioSource hurtSource;
    [SerializeField] private AudioSource powerHitSource;

    private Coroutine flashCoroutine;
    private Color flashColor = Color.red;

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
        if (isStunnable) Stun();
        Flash(3);
    }


    public void ApplyKnockback(Vector3 force)
    {
        // If the object has a mover component
        if (mover != null)
        {
            force *= ((maxHealth - health)/100) * knockbackMultiplier;
            mover.ApplyKnockback(force);
            mover.grounded = false;

            // If it's particularly strong, play the powerhit sound
            if (powerHitSource && force.magnitude > powerHitThresh)
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

    private void Flash(int numberOfFlashes)
    {
        if (flashCoroutine != null) StopCoroutine(flashCoroutine);
        flashCoroutine = StartCoroutine(FlashCoroutine(numberOfFlashes));
    }

    private IEnumerator FlashCoroutine(int numberOfFlashes)
    {
        Renderer renderer = GetComponent<Renderer>();
        float lerpAmount = Mathf.Clamp01(health/maxHealth);
        Color lerpedColor = Color.Lerp(flashColor, Color.yellow, lerpAmount);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            renderer.material.color = lerpedColor;
            yield return new WaitForSeconds(0.1f);
            renderer.material.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            i++;
        }
        flashCoroutine = null;
    }
}
