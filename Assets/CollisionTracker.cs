using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTracker : MonoBehaviour
{
    public Collider col;
    public List<Collider> currentColliders;

    private void OnTriggerEnter(Collider other)
    {
        currentColliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentColliders.Remove(other);
    }
}