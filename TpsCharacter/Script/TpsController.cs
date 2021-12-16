using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player Movement and Camera move around the player
/// </summary>

public class TpsController : MonoBehaviour
{
    [Tooltip("Player's Character controller")]
    public CharacterController controller;
    [Tooltip("Main Camera of the Scene")]
    public Transform cam;

    [Tooltip("Player's Speed")]
    public float speed;
    [Tooltip("Gravity of the map")]
    public float gravity = -9.81f;
    [Tooltip("Power of the Player's Jump")]
    public float jumpHeight = 3f;

    [Tooltip("Time for the player to turn when you move the camera")]
    public float turnSmoothTime = 0.1f;
    [Tooltip("Speed of the turn")]
    float turnSmoothVelocity;

    [Tooltip("GameObject wich detect if the player is on the air or on the ground")]
    public Transform groudCheck;
    [Tooltip("Distance of the Ground's detector")]
    public float groundDistance = 0.4f;
    [Tooltip("the Layer you put for detect the ground")]
    public LayerMask groundMask;

    [Tooltip("Boolean for say if the player is on the ground or in the air")]
    bool isGrounded;
    [Tooltip("Velocity of the player for move")]
    Vector3 velocity;

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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // move the camera when the player move his mouse
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

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
