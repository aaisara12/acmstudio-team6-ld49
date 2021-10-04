using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundElement : MonoBehaviour
{
    bool hasBeenInitialized = false;
    float elementSpeed = 0;
    float lifetime = 15;
    float timeOfInitialization = 0;

    public void Initialize(float speed)
    {
        elementSpeed = speed;
        hasBeenInitialized = true;
        timeOfInitialization = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasBeenInitialized) {return;}

        if(timeOfInitialization - Time.time > lifetime)
            Destroy(this.gameObject);
            
        transform.Translate(Vector3.right * elementSpeed * Time.deltaTime);
    }
}
