using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{

    [SerializeField] float maxSpeed = 5;
    [SerializeField] float currentSpeed = 0;
    float currentVelocity;
    [SerializeField] float smoothTime = 0.1f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = Mathf.SmoothDamp(currentSpeed, Input.GetAxisRaw("Horizontal") * maxSpeed, ref currentVelocity, smoothTime);
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }
}
