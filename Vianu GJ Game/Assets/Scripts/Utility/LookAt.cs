using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Vector3 cameraDirection = mainCameraTransform.position - transform.position;

        float yRotation = Mathf.Atan2(cameraDirection.x, cameraDirection.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
