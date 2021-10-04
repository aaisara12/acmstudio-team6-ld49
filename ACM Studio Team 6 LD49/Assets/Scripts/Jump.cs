using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    const float GRAVITY = 9.8f;

    ///////////////
    // Inputs
    ///////////////

    [SerializeField] float jumpHeight = 3;
    float jumpCooldown = 0.1f;
    float groundCheckDepth = 0.1f;
    
    
    // Calculate the jump speed needed to reach the specified jump height
    float jumpSpeed => Mathf.Sqrt(2 * GRAVITY * rb.gravityScale * jumpHeight);



    ///////////////
    // References
    ///////////////

    [SerializeField] Transform characterFeet;
    [SerializeField] ParticleSystem jumpEffect;
    Rigidbody2D rb;


    /////////////
    // Data
    /////////////

    bool hasPressedJump = false;
    bool isGrounded = false;
    float lastJumpTime = 0;

    bool hasDoubleJumped = false;

    bool isHardGrounded => isGrounded && rb.velocity.y < 0.1f;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // If we're touching the ground and haven't tried to jump for at least 0.1 seconds (prevent spamming) and we're pressing the jump key
        if(
            (isGrounded && Input.GetKey(KeyCode.Space)) ||
            (!isGrounded && Input.GetKeyDown(KeyCode.Space) && !hasDoubleJumped)
        )   
        {
            hasPressedJump = true;
        }

        // If we're touching the ground and have a stabilized resting velocity and have exhausted our double jump
        if(isHardGrounded && hasDoubleJumped)
            hasDoubleJumped = false;
            
        // Check if the player is touching the ground
        isGrounded = Physics2D.BoxCast(characterFeet.position, new Vector2(1, 0.01f), 0, Vector2.down, groundCheckDepth, LayerMask.GetMask("Ground"));

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(characterFeet.position + (Vector3.down * groundCheckDepth/2), new Vector3(1, groundCheckDepth, 0));
    }


    void FixedUpdate()
    {
        // If the player has requested to jump
        if(hasPressedJump)
        {
            // If it's been past the jump cooldown
            if(Time.time - lastJumpTime > jumpCooldown)
            {
                ParticleSystem particleSystem = Instantiate<ParticleSystem>(jumpEffect, characterFeet.transform.position, characterFeet.transform.rotation);
                Destroy(particleSystem, 1);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                lastJumpTime = Time.time;

                // If we're jumping while in the air, we have double jumped
                if(!isGrounded)
                    hasDoubleJumped = true;
            }

            // We have successfully processed the jump request
            hasPressedJump = false;
            
        }

        
    }
}
