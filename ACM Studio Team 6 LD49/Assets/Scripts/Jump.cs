using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    ///////////////
    // Inputs
    ///////////////

    [SerializeField] float jumpForce = 100;
    [SerializeField] float groundCheckDepth = 0.5f;
    [SerializeField] float jumpCooldown = 0.5f;



    ///////////////
    // References
    ///////////////

    [SerializeField] Transform characterFeet;
    Rigidbody2D rb;


    /////////////
    // Data
    /////////////

    bool hasPressedJump = false;
    bool isGrounded = false;
    float lastJumpTime = 0;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // If we're touching the ground and haven't tried to jump for at least 0.1 seconds (prevent spamming) and we're pressing the jump key
        if(isGrounded && Input.GetKey(KeyCode.Space))
        {
            hasPressedJump = true;
        }
            
        // Check if the player is touching the ground
        isGrounded = Physics2D.BoxCast(characterFeet.position, new Vector2(1, 0.01f), 0, Vector2.down, groundCheckDepth, LayerMask.GetMask("Ground"));

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(characterFeet.position + (Vector3.down * groundCheckDepth/2), new Vector3(1, groundCheckDepth, 0));
    }

    // Problem: We don't wan
    void FixedUpdate()
    {
        // If the player has requested to jump and they are not falling (velocities can cancel in weird ways)
        if(hasPressedJump && rb.velocity.y >= 0)
        {
            // If it
            if(Time.time - lastJumpTime > jumpCooldown)
            {
                rb.AddForce(Vector2.up * jumpForce);
                lastJumpTime = Time.time;
            }
            hasPressedJump = false;
            
        }
    }
}
