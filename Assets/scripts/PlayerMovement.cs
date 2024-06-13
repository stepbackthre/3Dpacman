using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; // Reference to the CharacterController component

    public float speed = 12f; // Movement speed of the player

    // Update is called once per frame
    void Update()
    {
        // Get input from player for horizontal and vertical movement
        float x = Input.GetAxis("Horizontal"); // -1 (left) to 1 (right)
        float z = Input.GetAxis("Vertical");   // -1 (backward) to 1 (forward)

        // Calculate movement direction based on player input
        Vector3 move = transform.right * x + transform.forward * z;

        // Move the player using CharacterController
        controller.Move(move * speed * Time.deltaTime);
    }
}
