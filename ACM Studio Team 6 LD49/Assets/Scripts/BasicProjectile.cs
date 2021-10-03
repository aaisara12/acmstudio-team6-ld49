using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float lifetimeSeconds = 5;

    float timeStart = 0;

    void Start()
    {
        timeStart = Time.time;
    }

    void Update()
    {
        // Best practices would have us use object pooling but we're in a bit of a rush :(
        if(Time.time - timeStart >= lifetimeSeconds)
            Destroy(this.gameObject);

        transform.Translate(transform.right * Time.deltaTime * speed);
    }

}
