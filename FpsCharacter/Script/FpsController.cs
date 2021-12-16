using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    [Tooltip("Player's Character controller")]
    public CharacterController controller;

    [Tooltip("Player's Speed")]
    public float speed = 12f;
    [Tooltip("Gravity of the map")]
    public float gravity = -9.81f;
    [Tooltip("Power of the Player's Jump")]
    public float jumpHeight = 3f;

    [Tooltip("GameObject wich detect if the player is on the air or on the ground")]
    public Transform groudCheck;
    [Tooltip("Distance of the Ground's detector")]
    public float groundDistance = 0.4f;
    [Tooltip("the Layer you put for detect the ground")]
    public LayerMask groundMask;

    [Tooltip("Velocity of the player for move")]
    Vector3 velocity;
    [Tooltip("Boolean for say if the player is on the ground or in the air")]
    bool isGrounded;

    // Start is called before the first frame update
    void Update()
    {
        //Create a sphere on the groundCheck position to detect if the player is on the ground
        isGrounded = Physics.CheckSphere(groudCheck.position, groundDistance, groundMask);

        // if he is, his velocity on the y axis is set to -2
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Set the movement of the player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // if the player jump and isGrounded is true he jump, if is Grounded is false nothing happen
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //Apply the gravity on the player
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
