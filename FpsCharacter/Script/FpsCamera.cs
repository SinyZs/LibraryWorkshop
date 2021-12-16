using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCamera : MonoBehaviour
{
    [Tooltip("Sensitivity of the player's mouse")]
    public float mouseSensitivity = 100f;

    [Tooltip("The transform of the player/ the object where FpsController is")]
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        //lock the cursor on the middle of the screen to move the camera only when the player move his mouse
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void Update()
    {
        //if the player move his mouse the camera follow the movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //the camera rotate with the player
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
