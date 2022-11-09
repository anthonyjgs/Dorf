// Reusable script to handle movement on both the player and npc characters
// Inputs/commands are handled via external scripts (such as a player controller or npc controller)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private float baseScale;
    private Vector3 velocity;
    private bool grounded;

    // Inputs to be accessed by other scripts
    public float moveInput; // From -1 to 1
    public bool jumpInput; // True means this character should jump

    public float moveSpeed = 2.0f;
    public float jumpPower = 1.0f;
    public float gravity = -9.8f;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        baseScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // If grounded, reset y velocity, if y velocity is positive, then we may be trying to jump and want to skip this
        grounded = controller.isGrounded;
        if (grounded && velocity.y !> 0) velocity.y = 0f;


        // Apply force of gravity, but let jumping override it for the first frame (inside ApplyInputs()), falling can be different speed
        velocity.y += gravity * Time.deltaTime;

        // Read any input values set by external scripts, and apply them
        ApplyInputs();

        // Move the character based on it's velocity values
        controller.Move(velocity * Time.deltaTime);
    }

    private void ApplyInputs()
    {
        // First, apply jumping if able
        if (jumpInput && grounded)
        {
            velocity.y = jumpPower;
            jumpInput = false;
        }

        // Then apply horizontal movement
        velocity.x = moveInput * moveSpeed;

        // Flip player to match desired direction of movement
        float yScale = transform.localScale.y;
        float zScale = transform.localScale.z;
        if (moveInput < 0) transform.localScale = new(-baseScale, yScale, zScale);
        else if (moveInput > 0) transform.localScale = new(baseScale, yScale, zScale);
    }
}
