using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensitivity of mouse movement

    public Transform playerBody; // Reference to the player's body transform

    private float xRotation = 0f; // Rotation around the x-axis (up and down look)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // Horizontal mouse movement
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // Vertical mouse movement

        xRotation -= mouseY; // Adjust the vertical rotation based on mouseY movement
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the vertical rotation to avoid flipping

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Apply vertical rotation to the camera
        playerBody.Rotate(Vector3.up * mouseX); // Rotate the player's body horizontally based on mouseX movement
    }
}
