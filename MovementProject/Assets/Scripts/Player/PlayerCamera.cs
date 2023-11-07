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
        float rotateX = UnityEngine.Input.GetAxis("Mouse X") * sensitivity;
        float rotateY = UnityEngine.Input.GetAxis("Mouse Y") * sensitivity;
        Debug.Log($"x = {rotateX}, y = {rotateY}");

        cameraTransform.localRotation = Quaternion.Euler(cameraTransform.localRotation.eulerAngles.x - rotateY, 0, 0);

        transform.Rotate(0, rotateX, 0);
    }
}
