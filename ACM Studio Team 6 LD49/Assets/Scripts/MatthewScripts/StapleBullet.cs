using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StapleBullet : MonoBehaviour
{
    public float speed = 6f;
    public Rigidbody2D rb;
    public int damage = 3;
    //public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    void Update()
    {
        if (transform.position.x <= -100)
        {
            Destroy(gameObject);
        }
    }

    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Debug.Log("lmao get no scoped");
        }
        //Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    

}
