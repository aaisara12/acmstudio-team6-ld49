using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [SerializeField] float jetpackForce = 5;

    bool hasPressedButton = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
            hasPressedButton = true;
    }

    void FixedUpdate()
    {
        if(hasPressedButton)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jetpackForce);
            hasPressedButton = false;
        }
    }
}
