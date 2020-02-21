using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMonoBehaviour : MonoBehaviour
{
    public Projectile projectile;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    private Rigidbody projectileRB;


    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        projectileRB = GetComponent<Rigidbody>();
        meshFilter.mesh = projectile.mesh;
        if (projectile.material != null)
        {
            meshRenderer.material = projectile.material;
        }
        meshCollider.sharedMesh = projectile.mesh;
        projectileRB.velocity = projectile.startingVelocityFloat * transform.forward;
    }

    //this entire callback handles bullet collision
    private void OnTriggerEnter(Collider collision)
    {
        CharacterStats collidedPlayerStats = collision.gameObject.GetComponent<CharacterStats>();   // checks to see if there is a "CharacterStats" object attached to the collided object
        if (collidedPlayerStats != null)                                                            // <---------|
        {
            collidedPlayerStats.TakeDamage(projectile.damage);                                      // if so, apply on-hit damage
        }

        // aoe handling
        if (projectile.isAoe)
        {
            Instantiate(projectile.aoeGameObject, this.transform.position, this.transform.rotation);
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, projectile.aoeRadius);
            if (hitColliders != null){
                for (int i=0; i<hitColliders.Length; i++)
                {
                    CharacterStats collidedPlayerStatsAoE = hitColliders[i].gameObject.GetComponent<CharacterStats>();
                    if (collidedPlayerStatsAoE != null)
                    {
                        collidedPlayerStatsAoE.TakeDamage(projectile.aoeDamage);
                    }
                    if (projectile.isExplosive)
                    {
                        Rigidbody rb = hitColliders[i].gameObject.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.AddExplosionForce(projectile.explosionForce, this.transform.position, projectile.aoeRadius * 2, 3.0F);
                        }
                    }
                }
            }
        }

        Destroy(this.gameObject);
    }
}
