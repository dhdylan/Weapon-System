using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour, IWeapon
{
    Rigidbody playerRigidbody;

    [SerializeField]    public Weapon equippedWeapon;
    [SerializeField]    private MeshFilter weaponMeshFilterComponent;
    [SerializeField]    private GameObject projectileGameObject; // creates a reference to a projectile prefab just for ease of use/tweaking
                        private ProjectileMonoBehaviour projectileMonoBehaviour;
    [SerializeField]    private Transform projectileEmitter;
    [SerializeField]    private Animator weaponAnimator;

    private float timeToFire;
    private int currentAmmo;
    private bool isReloading;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        isReloading = false;
        timeToFire = 0;
    }
    
    public void SetWeapon(Weapon weapon)
    {
        equippedWeapon = weapon;
        weaponMeshFilterComponent.mesh = weapon.weaponMesh;
        ProjectileMonoBehaviour projectileMonoBehaviour = projectileGameObject.GetComponent<ProjectileMonoBehaviour>();
        projectileMonoBehaviour.projectile = equippedWeapon.projectile;
        currentAmmo = equippedWeapon.magSize;
    }

    public void Zoom()
    {
        weaponAnimator.SetBool("isZoomed", true);
    }

    public void Unzoom()
    {
        weaponAnimator.SetBool("isZoomed", false);
    }

    public void Shoot()
    {
        if (currentAmmo > 0 && Time.time >= timeToFire)             // <---o   this is how fire rate works
        {                                                           //     |
            timeToFire = Time.time + 1f / equippedWeapon.fireRate;  // <---o
            Instantiate(projectileGameObject, projectileEmitter.position, projectileEmitter.rotation);  // insantiate a new projectileGameObject which is based on the currents weapon's projectile object
            currentAmmo = currentAmmo - 1;

            if (currentAmmo <= 0)   // reloading
            {
                StartCoroutine(Reload());
                return;
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        weaponAnimator.SetBool("isReloading", true);
        yield return new WaitForSeconds(equippedWeapon.reloadTime);
        currentAmmo = equippedWeapon.magSize;

        isReloading = false;
        weaponAnimator.SetBool("isReloading", false);
    }
}
