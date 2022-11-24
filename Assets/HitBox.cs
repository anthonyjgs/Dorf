using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private List<GameObject> hitObjects = new List<GameObject>();
    private List<Collider> exemptColliders = new List<Collider>();
    public Attack currentAttack;
    public Vector3 attackDirection = Vector3.right;

    private void OnEnable()
    {
        hitObjects.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: " + other.ToString());

        if (exemptColliders.Contains(other) == false && hitObjects.Contains(other.gameObject))
        {
            CharacterHealth otherHealth = other.gameObject.GetComponent<CharacterHealth>();
            otherHealth.ApplyDamage(currentAttack.damage);
            otherHealth.ApplyKnockback(currentAttack.knockback, attackDirection);
            hitObjects.Add(other.gameObject);
        }
    }
}
