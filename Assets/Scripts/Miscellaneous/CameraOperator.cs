using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOperator : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField]
    private Transform yRotatorTransform;
    private float rotationSensitivity;

    [SerializeField]
    private FloatVariable RotationSensitivity;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        rotationSensitivity = RotationSensitivity.runtimeValue;
    }

    // Update is called once per frame
    void Update()
    {
        rotateWithMouse();
    }

    private void rotateWithMouse()
    {
        float deltaX = Input.GetAxisRaw("Mouse X");
        float deltaY = Input.GetAxisRaw("Mouse Y");

         deltaX *= rotationSensitivity;
        deltaY *= rotationSensitivity;

        Vector3 cameraEulers = cameraTransform.rotation.eulerAngles;
        Vector3 yRotatorEulers = yRotatorTransform.rotation.eulerAngles;

        cameraEulers.x -= deltaY;
        yRotatorEulers.y += deltaX;
        cameraEulers.z = 0;

        cameraTransform.rotation = Quaternion.Euler(cameraEulers);
        yRotatorTransform.rotation = Quaternion.Euler(yRotatorEulers);


    }
}
