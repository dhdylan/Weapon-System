using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWeapon : MonoBehaviour
{
    // reference to the weapon controller script
    [SerializeField] private WeaponController weaponController;

    //

    [SerializeField] private Mesh projectileMesh;
    [SerializeField] private Material projectileMaterial;
    [SerializeField] private int projectileDamage;
    [SerializeField] private float projectileStartingVelocityFloat;
    
    [SerializeField] private bool projectileIsAoe;
    [SerializeField] private GameObject aoeGameObject;
    [SerializeField] private bool projectileIsExplosive;
    [SerializeField] private float projectileExplosionForce;
    [SerializeField] private float projectileAoeRadius;
    [SerializeField] private int projectileAoeDamage;

    //

    [SerializeField] private Mesh weaponMesh;
    [SerializeField] private Material weaponMaterial;
    [SerializeField] private FiringMode firingMode;
    [SerializeField] private float fireRate;
    [SerializeField] private int magSize;
    [SerializeField] private float reloadTime;
    [SerializeField] private float zoomModifier;

    private void Start()
    {
        weaponController = GetComponent<WeaponController>();
        if(weaponController == null)
        {
            Debug.Log("crap");
        }
    }

    // 
    public void SetWeapon()
    {
        // creates a new projectile object with the parameters input from the inspector
        Projectile projectile = new Projectile(projectileMesh, projectileMaterial, projectileDamage, projectileStartingVelocityFloat, projectileIsAoe, aoeGameObject, projectileIsExplosive, projectileExplosionForce, projectileAoeRadius, projectileAoeDamage);
        
        // creates a new weapon object using the parameters set in the inspector. uses the above projectile object
        Weapon weapon = new Weapon(weaponMesh, weaponMaterial, zoomModifier, magSize, projectile, reloadTime, firingMode, fireRate);
        
        weaponController.SetWeapon(weapon);
    }
}
