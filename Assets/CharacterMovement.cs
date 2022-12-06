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
    public bool grounded;
    [SerializeField] private bool airMovement = true;


    // Inputs to be accessed by other scripts
    public bool jumpInput; // True means this character should jump
    public bool canChangeDirection = true; // Disable during attacking
    public float moveSpeed = 2.0f;
    public float jumpPower = 1.0f;
    public float gravity = -9.8f;

    // Footstep Stuff
    public AudioSource audioSource;
    public AudioClip walkSound;
    private float footstepTimer = 0f;
    public float footstepRate = 0.5f;
    public bool pitchShift = true;
    public float shiftAmount = 1.0f;
    private float basePitch;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        baseScale = transform.localScale.x;

        if (audioSource != null) basePitch = audioSource.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        // Apply force of gravity, but let jumping override it for the first frame (inside ApplyInputs()), falling can be different speed
        velocity.y += gravity * Time.deltaTime;

        // Move the character based on it's velocity values
        controller.Move(velocity * Time.deltaTime);
    }

    public void ApplyInputs(float moveInput)
    {
        // Input is measured on scale of -1 to 1
        Mathf.Clamp(moveInput, -1.0f, 1.0f);

        // First, apply jumping if able
        if (jumpInput && grounded)
        {
            velocity.y = jumpPower;
            jumpInput = false;
        }

        // Then apply horizontal movement
        float moveAmount = moveInput * moveSpeed;
        if (airMovement || grounded)
        {
            velocity.x = moveAmount;
        }

        // If grounded and moving, play footstep sound
        if (audioSource != null)
        {
            footstepTimer -= Time.deltaTime;
            if (moveInput != 0 && grounded && footstepTimer <= 0)
            {
                footstepTimer = footstepRate;
                audioSource.clip = walkSound;
                if (pitchShift) audioSource.pitch = Random.Range(basePitch - shiftAmount, basePitch + shiftAmount);
                audioSource.Play();
            }
        }

        // Flip player to match desired direction of movement
        if (canChangeDirection)
        {       
            float yScale = transform.localScale.y;
            float zScale = transform.localScale.z;
            if (moveInput < 0) transform.localScale = new(-baseScale, yScale, zScale);
            else if (moveInput > 0) transform.localScale = new(baseScale, yScale, zScale);
        }
    }

    void LateUpdate()
    {
        // If grounded, reset y velocity, if y velocity is positive, then we may be trying to jump and want to skip this
        grounded = controller.isGrounded;
        if (grounded && velocity.y < 0) velocity.y = 0f;
    }

    public void ApplyKnockback(Vector3 force)
    {
        // TODO**************************************************
        velocity.x = force.x;
        velocity.y = force.y;
    }


    public Vector3 getVelocity()
    {
        return velocity;
    }
}
