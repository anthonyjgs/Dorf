using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;

public class CharacterAttacker : MonoBehaviour
{
    private bool isAttacking = false;
    private bool attackQueued = false;
    [SerializeField] private GameObject hurtBox;
    private CollisionTracker colTracker;
    private List<GameObject> damagedObjects = new List<GameObject>();
    [SerializeField] private Animator animator;

    // Attacks to use
    [SerializeField] private Attack[] attacks;
    [SerializeField] private bool attackChain = true; // Will attacks be in a chain order, or random?
    private int attackIndex = 0;
    
    private Attack currentAttack;
    private bool hurtActive = false;

    private void Start()
    {
        colTracker = hurtBox.GetComponent<CollisionTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hurtActive)
        {
            // Deal damage and knockback based on the current attack of the attack index 
            List<Collider> currentColliders = colTracker.currentColliders;
            // Deal damage to any new objects in the hurtbox
            for (int i = 0; i < currentColliders.Count; i++)
            {
                GameObject currentObject = currentColliders[i].gameObject;
                if (damagedObjects.Contains(currentObject) == false)
                {
                    damagedObjects.Add(currentObject);

                    // Apply damage and knockback to the current object
                    if (currentObject.TryGetComponent(out CharacterHealth objHealth))
                    {
                        objHealth.ApplyDamage(attacks[attackIndex].damage);
                        objHealth.ApplyKnockback(attacks[attackIndex].knockback);
                    }
                }
            }
        }
    }

    // The attack to use is determined by the animation controller, and actually turning on and off the hurtbox is handled called from animation events
    public void UseAttack()
    {
        Debug.Log("UseAttack called!");
        // If not already attacking, start attacking
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetBool("isAttacking", true);
            attackIndex = 0;
        }
        else
        {   // Otherwise, queue an attack
            attackQueued = true;
        }
    }

    // Called by an animation event when an attack is over
    public void EndAttack()
    {
        Debug.Log("EndAttack called! AND attackQueued: " + attackQueued);
        if (attackQueued == true)
        {
            attackIndex = (attackIndex < attacks.Length) ? attackIndex += 1 : attackIndex = 0;
            attackQueued = false;
        }
        else
        {
            isAttacking = false;
            animator.SetBool("isAttacking", false);
        }
    }

    // Called by an animation event when an attack can deal damage
    public void ActivateHurtBox()
    {
        hurtActive = true;
        
    }

    // Called by an animation event when an attack can no longer deal damage
    public void DeactivateHurtBox()
    {
        hurtActive = false;
        damagedObjects.Clear();
    }
}
