using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Attack", fileName = "New Attack")]
public class Attack : ScriptableObject
{
    public float damage = 10f;
    public float knockback = 10f;
}
