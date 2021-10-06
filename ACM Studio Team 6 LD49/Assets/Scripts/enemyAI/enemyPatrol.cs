using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [SerializeField] float speed;
    private float distance;
    private bool movingRight = true;
    public Transform groundDetection;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce;
    private bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    public Transform isGroundedCheck;

    public float countDown;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(isGroundedCheck.position, 0.2f, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= -3)
        {
            Destroy(this.gameObject);
        }
        if (countDown <= 0)
        {
            transform.position += new Vector3(1, 0, 0);
            return;
        }
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        int randInt = Random.Range(0, 100);
        if (groundInfo.collider == true)
        {
            if (randInt == 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            if (randInt == 1)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (randInt == 2 && isGrounded)
            {
                Jump();
            }
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } 
            else 
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
