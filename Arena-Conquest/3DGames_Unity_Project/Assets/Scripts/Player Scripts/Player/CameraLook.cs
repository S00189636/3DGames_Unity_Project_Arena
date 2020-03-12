using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    
    public float horizontalSpeed;
    public float verticalSpeed;
    public Camera lookCamera;
    private float upRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed * Time.deltaTime;

        upRotation -= mouseY;
        upRotation = Mathf.Clamp(upRotation, -30, 25);

        lookCamera.transform.localRotation = Quaternion.Euler(upRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}

