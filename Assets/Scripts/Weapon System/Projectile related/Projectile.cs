using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Projectile", order = 51)]

public class Projectile : ScriptableObject
{
    public Mesh projectileMesh;
    public Material projectileMaterial;

    public int damage;
    public float startingVelocityFloat;
    public Vector3 startingVelocityTransform;

    //public bool isNested;
    //public Projectile nestedProjectile;
    //public int numberOfNestedProjectiles;

    public bool isAoE;
    public GameObject AoEObject;
    public bool isExplosive;
    public float explosionForce;
    public float AoERadius;
    public int AoeDamage;
}
