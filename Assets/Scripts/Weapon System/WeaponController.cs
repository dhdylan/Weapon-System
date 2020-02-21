using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour, IWeapon
{
    Rigidbody playerRigidbody;

    [SerializeField]    public Weapon equippedWeapon;
                        private GameObject equippedWeaponGameObject;
    [SerializeField]    private GameObject weaponGameObjectTemplate;
                        private WeaponMonoBehaviour weaponMonoBehaviour;
    [SerializeField]    private GameObject projectileGameObjectTemplate;
                        private ProjectileMonoBehaviour projectileMonoBehaviour;
    [SerializeField]    private Transform projectileEmitter;
    [SerializeField]    private Transform weaponDropper;
    [SerializeField]    private Animator weaponAnimator;

    private float timeToFire;
    private int currentAmmo;
    private bool isReloading;

    void Start()
    {
        equippedWeaponGameObject = GameObject.Find("EquippedWeapon");
        weaponMonoBehaviour = weaponGameObjectTemplate.GetComponent<WeaponMonoBehaviour>();
        projectileMonoBehaviour = projectileGameObjectTemplate.GetComponent<ProjectileMonoBehaviour>();
        playerRigidbody = GetComponent<Rigidbody>();
        isReloading = false;
        timeToFire = 0;
    }
    
    public void SetWeapon(Weapon weapon)
    {
        equippedWeapon = weapon;
        equippedWeaponGameObject.GetComponent<MeshFilter>().mesh = weapon.mesh;
        equippedWeaponGameObject.GetComponent<MeshRenderer>().material = weapon.material;
        projectileMonoBehaviour.projectile = equippedWeapon.projectile;
        currentAmmo = equippedWeapon.magSize;
    }

    public void RemoveWeapon()
    {
        weaponMonoBehaviour.weapon = equippedWeapon;
        equippedWeapon = null;
        equippedWeaponGameObject.GetComponent<MeshFilter>().mesh = null;
        equippedWeaponGameObject.GetComponent<MeshRenderer>().material = null;
        currentAmmo = 0;
        Instantiate(weaponGameObjectTemplate, weaponDropper.position, weaponDropper.rotation);
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
            Instantiate(projectileGameObjectTemplate, projectileEmitter.position, projectileEmitter.rotation);  // insantiate a new projectileGameObject which is based on the currents weapon's projectile object
            currentAmmo = currentAmmo - 1;

            if (currentAmmo <= 0 && equippedWeapon != null)   // reloading
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
