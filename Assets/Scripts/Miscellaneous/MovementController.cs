using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody userRB;
    [SerializeField]
    private MovementSettings userMovementSettings;

    private float speed;
    private float jumpForce;

    private void Start()
    {
        speed = userMovementSettings.Speed;
        jumpForce = userMovementSettings.JumpForce;
    }

    public void lookAtTarget(GameObject target)
    {
        this.transform.LookAt(target.transform);
    }

    public void move(float moveX, float moveZ)
    {
        float movementX = moveX * Time.deltaTime;
        float movementZ = moveZ * Time.deltaTime;

        userRB.MovePosition(this.transform.position + ((transform.forward * movementZ) + (transform.right * movementX)).normalized * speed);
        userRB.AddRelativeForce(new Vector3(movementX, 0, movementZ).normalized * speed, ForceMode.VelocityChange);
    }

    public void Jump()
    {
        userRB.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}
