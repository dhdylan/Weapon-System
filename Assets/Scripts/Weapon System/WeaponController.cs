using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour, IWeapon
{
    [SerializeField]
    public Weapon equippedWeapon;
    [SerializeField]
    private MeshFilter weaponMeshFilterComponent;

    [SerializeField]
    private GameObject projectileTemplate;
    private ProjectileMonoBehaviour projectileMonoBehaviour;
    
    [SerializeField]
    private Transform projectileEmitter;
    [SerializeField]
    private Animator weaponAnimator;

    Rigidbody playerRigidbody;

    private float timeToFire;
    private int currentAmmo;
    private float reloadTime;
    private bool isReloading;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        isReloading = false;
        timeToFire = 0;
    }
    
    public void SetWeapon(Weapon weapon)
    {
        Debug.Log("wepon controller set weapon called");
        equippedWeapon = weapon;
        weaponMeshFilterComponent.mesh = weapon.weaponMesh;
        currentAmmo = equippedWeapon.magSize;
    }

    public void zoom()
    {
        weaponAnimator.SetBool("isZoomed", true);
    }

    public void unzoom()
    {
        weaponAnimator.SetBool("isZoomed", false);
    }

    public void Shoot()
    {
        if (currentAmmo > 0 && Time.time >= timeToFire)
        {
            equippedWeapon.projectile.startingVelocityTransform = playerRigidbody.velocity + (equippedWeapon.projectile.startingVelocityFloat * GameObject.Find("Main Camera").transform.forward);

            timeToFire = Time.time + 1f / equippedWeapon.fireRate;
            ProjectileMonoBehaviour projectileMonoBehaviour = projectileTemplate.GetComponent<ProjectileMonoBehaviour>();
            projectileMonoBehaviour.projectile = equippedWeapon.projectile;
            Instantiate(projectileTemplate, projectileEmitter.position, projectileEmitter.rotation);
            currentAmmo = currentAmmo - 1;

            if (currentAmmo <= 0)
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
