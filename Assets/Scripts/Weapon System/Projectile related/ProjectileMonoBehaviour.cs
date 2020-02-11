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
        meshFilter.mesh = projectile.projectileMesh;
        if (projectile.projectileMaterial != null)
        {
            meshRenderer.material = projectile.projectileMaterial;
        }
        meshCollider.sharedMesh = projectile.projectileMesh;
        projectileRB.velocity = projectile.startingVelocityTransform;
    }
    private void OnTriggerEnter(Collider collision)
    {
        // projectile on-hit damage handling
        Debug.Log("hit" + collision.gameObject.name);
        CharacterStats collidedPlayerStats = collision.gameObject.GetComponent<CharacterStats>();
        if (collidedPlayerStats != null)
        {
            collidedPlayerStats.TakeDamage(projectile.damage);
        }

        // AoE handling
        if (projectile.isAoE)
        {
            Instantiate(projectile.AoEObject, this.transform.position, this.transform.rotation);
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, projectile.AoERadius);
            if (hitColliders != null){
                for (int i=0; i<hitColliders.Length; i++)
                {
                    CharacterStats collidedPlayerStatsAoE = hitColliders[i].gameObject.GetComponent<CharacterStats>();
                    if (collidedPlayerStatsAoE != null)
                    {
                        collidedPlayerStatsAoE.TakeDamage(projectile.AoeDamage);
                    }
                    if (projectile.isExplosive)
                    {
                        Rigidbody rb = hitColliders[i].gameObject.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.AddExplosionForce(projectile.explosionForce, this.transform.position, projectile.AoERadius * 2, 3.0F);
                        }
                    }
                }
            }
        }
        Destroy(this.gameObject);
    }
}
