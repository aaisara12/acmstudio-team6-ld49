using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRider : MonoBehaviour
{
    [SerializeField] Transform feetTransform;
    Rigidbody2D rb;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.otherCollider.CompareTag("Platform") && 
            rb.velocity.y < 0.01f && 
            feetTransform.position.y > col.otherCollider.transform.position.y)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
