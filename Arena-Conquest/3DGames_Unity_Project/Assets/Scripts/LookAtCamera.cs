using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform Camera;
    private void Update()
    {
        transform.LookAt(
            transform.position + Camera.rotation * Vector3.forward,
            Camera.rotation * Vector3.up);
    }
}