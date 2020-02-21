using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Projectile", order = 51)]

public class Projectile : ScriptableObject
{
    public Mesh mesh;
    public Material material;

    public int damage;
    public float startingVelocityFloat;
    public bool isAoe;

    public GameObject aoeGameObject;
    public bool isExplosive;
    public float explosionForce;
    public float aoeRadius;
    public int aoeDamage;

    public Projectile(Mesh projectileMesh, Material projectileMaterial, int projectileDamage, float projectileStartingVelocityFloat, bool projectileIsAoe, GameObject aoeGameObject, bool projectileIsExplosive, float explosionForce, float aoeRadius, int aoeDamage)
    {
        this.mesh = projectileMesh;
        this.material = projectileMaterial;
        this.damage = projectileDamage;
        this.startingVelocityFloat = projectileStartingVelocityFloat;
        this.isAoe = projectileIsAoe;
        this.aoeGameObject = aoeGameObject;
        this.aoeRadius = aoeRadius;
        this.aoeDamage = aoeDamage;
        this.isExplosive = projectileIsExplosive;
        this.explosionForce = explosionForce;
    }
}
