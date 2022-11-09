using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Attack", fileName = "New Attack")]
public class Attack : ScriptableObject
{
    public float startUp = 1.0f;
    public float active = 0.5f;
    public float recovery = 2.0f;
    public float damage = 1.0f;
    public Collider hurtBox;
}
