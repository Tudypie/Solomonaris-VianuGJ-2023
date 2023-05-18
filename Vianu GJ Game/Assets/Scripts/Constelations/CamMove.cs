using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float speed = 15f;
    public Vector2 minXMaxX;
    public Vector2 minYMaxY;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Apply boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minXMaxX.x, minXMaxX.y);
        newPosition.y = Mathf.Clamp(newPosition.y, minYMaxY.x, minYMaxY.y);

        transform.position = newPosition;
    }
}
