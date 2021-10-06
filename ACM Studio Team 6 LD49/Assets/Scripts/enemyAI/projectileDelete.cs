using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDelete : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        // add code to debuff character (slow movement & disable arrows)
        if (col.gameObject.name == "Player")
        {
            Debug.Log("hit player");
        }
        if (col.gameObject.name == "Floor")
        {
            Destroy(this.gameObject);
        }
    }
}
