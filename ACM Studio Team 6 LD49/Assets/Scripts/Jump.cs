using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float jumpForce = 100;

    bool hasPressedJump = false;
    bool isGrounded = false;
    [SerializeField] float groundCheckDepth = 0.5f;
    [SerializeField] Transform characterFeet;

    float lastJumpTime = 0;

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
        if(hasPressedJump)
        {
            if(Time.time - lastJumpTime > 0.5f)
            {
                Debug.Log("Jumping");
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
                lastJumpTime = Time.time;
            }
            hasPressedJump = false;
            
        }
    }
}
