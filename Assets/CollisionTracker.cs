using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTracker : MonoBehaviour
{
    public Collider col;
    public List<Collider> currentColliders = new List<Collider>();
    private Collider[] exemptColliders;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: " + other.ToString());
        exemptColliders = GetComponentsInParent<Collider>();

        bool isExempt = false;
        for (int i = 0; i < exemptColliders.Length; i++)
        {
            if (exemptColliders[i] == other)
            {
                isExempt = true;
                break;
            }
        }
        if (!isExempt) currentColliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentColliders.Contains(other)) currentColliders.Remove(other);
    }
}