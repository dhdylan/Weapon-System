using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWeapon : MonoBehaviour
{
    public Mesh weaponMesh;
    public FiringMode firingMode;
    public float fireRate;
    public int magSize;
    public float reloadTime;
    public float zoomModifier;
    public Mesh projectileMesh;
    public int projectileDamage;
    public float projectileStartingVelocityFloat;
    public bool projectileIsAoe;
    public bool projectileIsExplosive;

    private WeaponController weaponController;

    private void Start()
    {
        SetWeapon();
    }

    public void SetWeapon()
    {
        weaponController = GetComponent<WeaponController>();
        Weapon weapon = new Weapon();
        weapon.weaponMesh = weaponMesh;
        weapon.firingMode = firingMode;
        weapon.fireRate = fireRate;
        weapon.magSize = magSize;
        weapon.reloadTime = reloadTime;
        weapon.zoomModifier = zoomModifier;
        Projectile projectile = new Projectile();
        projectile.projectileMesh = projectileMesh;
        projectile.damage = projectileDamage;
        projectile.startingVelocityFloat = projectileStartingVelocityFloat;
        projectile.isAoE = projectileIsAoe;
        projectile.isExplosive = projectileIsExplosive;
        weapon.projectile = projectile;
        weaponController.SetWeapon(weapon);
    }
}
