using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StapleShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timeSinceLastPew = 0;
    public float pewDelayTime = 4;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (timeSinceLastPew >= pewDelayTime)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timeSinceLastPew = 0;
        }
        else
        {
            timeSinceLastPew += Time.deltaTime;
        }

    }
}
