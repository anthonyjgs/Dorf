using System.Collections.Generic;
using UnityEngine;

public class CharacterAttacker : MonoBehaviour
{
    public bool isAttacking = false;
    private bool attackQueued = false;
    public bool isDirectionLocked = false;
    private CollisionTracker colTracker;
    private List<GameObject> damagedObjects = new List<GameObject>();
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioSource audioSource;

    // Attacks to use
    [SerializeField] private Attack[] attacks;
    private int attackIndex = 0;

    private Attack currentAttack;
    private bool hurtActive = false;
    [SerializeField] private float knockHeightBonus = 1.0f;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        if (audioSource == null) audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hurtActive == true)
        {
            if (isAttacking == false) hurtActive = false;
            else CheckHitBox();
        }
    }

    // The attack to use is determined by the animation controller, and actually turning on and off the hitbox is handled called from animation events
    public void UseAttack()
    {
        // If not already attacking, start attacking
        if (!isAttacking)
        {
            isAttacking = true;
            isDirectionLocked = true;
            attackIndex = 0;
            currentAttack = attacks[attackIndex];
            animator.Play(currentAttack.animationString);
        }
        else
        {   // Otherwise, queue an attack
            attackQueued = true;
        }
    }

    // Called by an animation event when an attack is over
    public void EndAttack()
    {
        if (attackQueued == true)
        {
            attackIndex = (attackIndex < attacks.Length - 1) ? attackIndex += 1 : attackIndex = 0;
            currentAttack = attacks[attackIndex];
            animator.Play(currentAttack.animationString);
            attackQueued = false;
            isDirectionLocked = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    // Called by an animation event when an attack can deal damage
    public void ActivateHitBox()
    {
        if (isAttacking == true)
        {
            hurtActive = true;
        }
    }

    public void InterruptAttack()
    {
        DeactivateHitBox();
        isAttacking = false;
        attackQueued = false;
        hurtActive = false;

    }

    // Called by an animation event when an attack can no longer deal damage
    public void DeactivateHitBox()
    {
        hurtActive = false;
        damagedObjects.Clear();
        isDirectionLocked = false;
    }

    // Overlap box that deals damage once per gameObject
    public void CheckHitBox()
    {
        Vector3 hitOrigin = GetRelativeOrigin(currentAttack.hitOrigin);
        Collider[] hitColliders = Physics.OverlapBox(hitOrigin, currentAttack.hitSize / 2);

        // Deal damage and knockback based on the current attack of the attack index 
        // Deal damage to any new objects in the 
        for (int i = 0; i < hitColliders.Length; i++)
        {
            GameObject currentObject = hitColliders[i].gameObject;

            // Only on colliders that are not already damaged and not self
            if (damagedObjects.Contains(currentObject) == false && currentObject != gameObject)
            {
                damagedObjects.Add(currentObject);
;

                // Apply damage and knockback to the current object
                if (currentObject.TryGetComponent(out CharacterHealth objHealth))
                {
                    // Setting up the attack direction for knockback
                    Vector3 attackDirection = (currentObject.transform.position - gameObject.transform.position);
                    attackDirection.Normalize();
                    attackDirection.y += knockHeightBonus;
                    objHealth.ApplyKnockback(attacks[attackIndex].knockback * attackDirection);
                    
                    objHealth.ApplyDamage(attacks[attackIndex].damage);
                    
                    if (hitSound != null && audioSource != null) audioSource.PlayOneShot(hitSound);
                }
                if (currentObject.TryGetComponent(out CharacterAttacker objAttacker))
                {
                    objAttacker.hurtActive = false;
                    objAttacker.InterruptAttack();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        if (hurtActive == true)
        {
            Vector3 hitOrigin = GetRelativeOrigin(currentAttack.hitOrigin);
            Gizmos.DrawCube(hitOrigin, currentAttack.hitSize);
        }
    }

    Vector3 GetRelativeOrigin(Vector3 origin)
    {
        Vector3 newOrigin;
        if (transform.localScale.x >= 0)
        {
            newOrigin = transform.position + origin;
        }
        else
        {
            newOrigin = transform.position + new Vector3(-origin.x, origin.y, origin.z);
        }

        return newOrigin;
    }
}
