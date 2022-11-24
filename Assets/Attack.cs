using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Attack", fileName = "New Attack")]
public class Attack : ScriptableObject
{
    public float damage = 10f;
    public float knockback = 10f;
    public Vector3 hitSize;
    public Vector3 hitOrigin;

    public string animationString = "Insert Animation Name Here";
}
