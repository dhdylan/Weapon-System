using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private MovementController movementController;
    private WeaponController weaponController;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        movementController = GetComponent<MovementController>();
        weaponController = GetComponent<WeaponController>();
    }

    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            movementController.move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        if (Input.GetButtonDown("Jump"))
        {
            movementController.Jump();
        }
    }

    private void Update()
    {
        if (weaponController.equippedWeapon.firingMode == FiringMode.single)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weaponController.Shoot();
            }
        }
        else if (weaponController.equippedWeapon.firingMode == FiringMode.auto)
        {
            if (Input.GetButton("Fire1"))
            {
                weaponController.Shoot();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weaponController.zoom();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            weaponController.unzoom();
        }
    }
}
