using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tack : MonoBehaviour
{
    public int damage = 5;
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("yo I hit the thumbtack");
            player.TakeDamage(damage);

        }
        //Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
    
}
