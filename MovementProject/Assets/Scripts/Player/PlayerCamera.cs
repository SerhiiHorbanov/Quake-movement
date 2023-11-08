using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;

    [SerializeField] float sensitivity;

    private void LateUpdate()
    {
        float rotateX = Input.GetAxis("Mouse X") * sensitivity;
        float rotateY = Input.GetAxis("Mouse Y") * sensitivity;

        cameraTransform.localRotation = Quaternion.Euler(cameraTransform.localRotation.eulerAngles.x - rotateY, 0, 0);

        transform.Rotate(0, rotateX, 0);
    }
}
