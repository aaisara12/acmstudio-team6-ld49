using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public int damage = 3;
    float startingPos;
    public float distCoveredWhenFlip = 10f;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position.x;
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(startingPos - transform.position.x) >= distCoveredWhenFlip) {
            startingPos = transform.position.x;
            rb.velocity = -1 * rb.velocity;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Debug.Log("clock hit player");
        }
        //Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
